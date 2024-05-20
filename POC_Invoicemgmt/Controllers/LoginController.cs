using App.Application.Login.Queries;
using App.Application.Login.Queries.RefreshToken;
using Microsoft.AspNetCore.Mvc;
using POC_Invoicemgmt.Common;

namespace POC_Invoicemgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : APIControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest loginRequest)
        {
            var loginResponse = await Mediator.Send(new GetLoginQuery { EmailId = loginRequest.EmailId, Password = loginRequest.Password });
            if (loginResponse is null)
            {
                return BadRequest();
            }
            return Ok(new ApiResponse<LoginResponseViewModel>("Success", 200, loginResponse));
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> GenerateRefreshToken(LoginRefreshTokenRequest loginTokenRequest)
        {
            var loginResponse = await Mediator.Send(new GetRefreshTokenQuery { token=loginTokenRequest.token,refreshtoken=loginTokenRequest.refreshtoken });
            if (loginResponse is null)
            {
                return BadRequest();
            }
            return Ok(new ApiResponse<LoginResponseViewModel>("Success", 200, loginResponse));
        }
    }
}
