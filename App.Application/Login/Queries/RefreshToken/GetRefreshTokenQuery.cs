using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.Login.Queries.RefreshToken
{
    public class GetRefreshTokenQuery:IRequest<LoginResponseViewModel>
    {
        [Required(ErrorMessage ="Token must not be empty.")]
        public string token { get; set; }

        [Required(ErrorMessage = "Refresh token must not be empty.")]
        public string refreshtoken { get; set; }
    }
}
