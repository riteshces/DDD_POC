using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.UserRegistrations.Queries
{
    public class UserRegistrationQuery : IRequest<UserRegistrationViewModel>
    {
        [Required(ErrorMessage = "Id must not be empty.")]
        public string Id { get; set; }
    }
}
