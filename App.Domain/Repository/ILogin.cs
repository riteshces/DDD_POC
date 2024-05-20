using App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repository
{
    public interface ILogin
    {
        Task<LoginUserResponse> LoginAsync(LoginUser login);

        Task<LoginUserResponse> GenerateRefreshToken(string token, string refreshtoken);
    }
}
