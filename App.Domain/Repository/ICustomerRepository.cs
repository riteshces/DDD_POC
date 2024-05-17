using App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repository
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerMaster>> GetCustomersAsync();
        public Task<CustomerMaster> GetCustomerByIdAsync(string id);
        public Task<CustomerMaster> AddCustomerAsync(CustomerMaster customer);
        public Task<CustomerMaster> UpdateCustomerAsync(string id, CustomerMaster customer);

    }
}
