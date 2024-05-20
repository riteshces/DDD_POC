using App.Domain.Entity;

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
