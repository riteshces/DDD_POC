using App.Domain.Entity;
using App.Domain.Repository;
using App.Infra.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _appDBContext;

        public CustomerRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<CustomerMaster> AddCustomerAsync(CustomerMaster customer)
        {
            await _appDBContext.CustomerMasters.InsertOneAsync(customer);
            return customer;
        }

        public async Task<CustomerMaster> GetCustomerByIdAsync(string id)
        {
            var filter = Builders<CustomerMaster>.Filter.Eq(c => c.Id, id);
            var customer = await _appDBContext.CustomerMasters.FindAsync(filter).Result.FirstOrDefaultAsync();
            return customer;
        }

        public async Task<List<CustomerMaster>> GetCustomersAsync()
        {
            var customers= await _appDBContext.CustomerMasters.Find(FilterDefinition<CustomerMaster>.Empty).ToListAsync();
            return customers;
        }

        public async Task<CustomerMaster> UpdateCustomerAsync(string id, CustomerMaster customer)
        {
            var filter = Builders<CustomerMaster>.Filter.Eq(c => c.Id, id);
            var update = Builders<CustomerMaster>.Update
                .Set(c => c.Address, customer.Address)
                .Set(c => c.City, customer.City)
                .Set(c => c.ContactNo, customer.ContactNo)
                .Set(c => c.Country, customer.Country)
                .Set(c => c.EmailId, customer.EmailId)
                .Set(c => c.CustomerName, customer.CustomerName)
                .Set(c => c.Pincode, customer.Pincode);
            var result=_appDBContext.CustomerMasters.UpdateOneAsync(filter, update);
            return await _appDBContext.CustomerMasters.FindAsync(filter).Result.FirstOrDefaultAsync();
        }
    }
}
