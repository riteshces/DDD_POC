using App.Application.Customer.Queries.GetCustomers;
using MediatR;

namespace App.Application.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerViewModel>
    {
        public string Id { get; set; }
    }
}
