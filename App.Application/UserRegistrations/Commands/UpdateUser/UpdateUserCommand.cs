using App.Application.Customer.Queries.GetCustomers;
using App.Application.UserRegistrations.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UserRegistrations.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserRegistrationViewModel>
    {
        [Required(ErrorMessage = "Id must not be empty.")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Name must not be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact No. must not be empty.")]
        [Length(10, 10, ErrorMessage = "Contact No. must be 10 digit.")]
        public string ContactNo { get; set; }
    }
}
