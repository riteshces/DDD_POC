using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Customer.Queries.GetCustomers
{
    public class GetCustomersQuery:IRequest<List<CustomerViewModel>>
    {
    }
}
