using App.Domain.Entity;
using App.Domain.Repository;
using App.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace App.Infra.Repository
{
    public class LoginRepository : ILogin
    {
        private readonly AppDBContext _appDBContext;
        private readonly IConfiguration _configuration;

        public LoginRepository(AppDBContext appDBContext, IConfiguration configuration)
        {
            _appDBContext = appDBContext;
            _configuration = configuration;
        }

        public async Task<LoginUserResponse> LoginAsync(LoginUser login)
        {
            var filter = Builders<UserRegistration>.Filter.Eq(u => u.EmailId, login.EmailId);
            UserRegistration user = await _appDBContext.UserRegistrations.FindAsync(filter).Result.FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User not found. Invalid Email Id.");
            }
            bool checkPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (!checkPassword)
            {
                throw new Exception("Invalid credentials.");
            }

            //generate token
            string token = GenerateToken(user);
            string refreshtoken = GenerateRefreshToken();
            bool isLogin = true;

            //update refresh token in database

            var userEntity = Builders<UserRegistration>.Update
                .Set(u => u.RefreshToken, refreshtoken)
                .Set(u => u.RefreshTokenExpiredOn, DateTime.Now.AddMinutes(60));
            await _appDBContext.UserRegistrations.UpdateOneAsync(filter, userEntity);

            //return response
            return new LoginUserResponse(isLogin, token, refreshtoken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private string GenerateToken(UserRegistration user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userclaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.EmailId)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userclaims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginUserResponse> GenerateRefreshToken(string token, string refreshtoken)
        {
            var principal = GetTokenPrincipal(token);

            var response = new LoginUserResponse(false, null, null);
            if (principal?.Identity?.Name is null)
                return response;

            var userid = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var filter = Builders<UserRegistration>.Filter.Eq(u => u.Id, userid);
            var user = _appDBContext.UserRegistrations.FindAsync(filter).Result.FirstOrDefault();

            if (user is null || user.RefreshToken != refreshtoken || user.RefreshTokenExpiredOn < DateTime.UtcNow)
                return response;

            bool isLogedIn = true;
            string jwtToken = GenerateToken(user);
            string refreshToken = GenerateRefreshToken();

            var userEntity = Builders<UserRegistration>.Update
                .Set(u => u.RefreshToken, refreshtoken)
                .Set(u => u.RefreshTokenExpiredOn, DateTime.Now.AddHours(1));
            await _appDBContext.UserRegistrations.UpdateOneAsync(filter, userEntity);

            return new LoginUserResponse(isLogedIn, jwtToken, refreshToken);
        }

        private ClaimsPrincipal? GetTokenPrincipal(string token)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var validation = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
    }
}
