using App.Application.UserRegistrations.Queries;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.UserRegistrations.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<UserRegistrationViewModel>
    {
        [Required(ErrorMessage ="User Name must not be empty.")]
        [Length(2,10,ErrorMessage ="User name character length must be between 2 and 10.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must not be empty.")]
        [Length(2, 10, ErrorMessage = "Password character length must be between 2 and 10.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name must not be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact No. must not be empty.")]
        [Length(10, 10, ErrorMessage = "Contact No. must be 10 digit.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Email Id must not be empty.")]
        [EmailAddress(ErrorMessage ="Incorrect Email Id")]
        public string EmailId { get; set; }
    }
}
