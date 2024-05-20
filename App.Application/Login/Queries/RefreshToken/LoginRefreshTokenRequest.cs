using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Login.Queries.RefreshToken
{
    public class LoginRefreshTokenRequest
    {
        [Required(ErrorMessage = "Token must not be empty.")]
        public string token { get; set; }

        [Required(ErrorMessage = "Refresh token must not be empty.")]
        public string refreshtoken { get; set; }
    }
}
