using App.Application.Customer.Queries.GetCustomers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery:IRequest<CustomerViewModel>
    {
        public string Id { get; set; }
    }
}
