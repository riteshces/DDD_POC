using App.Application.Customer.Queries.GetCustomers;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CustomerViewModel>
    {
        [Required(ErrorMessage = "Customer name must not be empty.")]
        [MaxLength(50, ErrorMessage = "Customer name must not be greater than 50 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address must not be empty.")]
        [MaxLength(500, ErrorMessage = "Address must not be greater than 500 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City must not be empty.")]
        [MaxLength(50, ErrorMessage = "City must not be greater than 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pincode must not be empty.")]
        [Length(6, 6, ErrorMessage = "Pincode must be 6 digit.")]
        public string Pincode { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "Contact No must not be empty.")]
        [Length(10, 10, ErrorMessage = "Contact No must be 10 digit.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Email id must not be empty.")]
        [EmailAddress(ErrorMessage = "Email id is incorrect.")]
        public string EmailId { get; set; }
    }
}
