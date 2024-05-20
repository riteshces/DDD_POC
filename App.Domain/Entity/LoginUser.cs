using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entity
{
    public class LoginUser
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

    public record LoginUserResponse(bool isLogin, string token, string refreshtoken);
}
