using MediatR;

namespace App.Application.Customer.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<List<CustomerViewModel>>
    {
    }
}
