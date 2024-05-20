using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Login.Queries
{
    public class GetLoginQuery:IRequest<LoginResponseViewModel>
    {
        [Required(ErrorMessage ="Email Id must not be empty.")]
        [EmailAddress(ErrorMessage ="Incorrect Email Id.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password must not be empty.")]
        public string Password { get; set; }
    }
}
