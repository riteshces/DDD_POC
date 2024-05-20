using App.Domain.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data
{
    public class AppDBContext
    {

        private readonly IMongoDatabase? _mongoDatabase;
        private readonly IConfiguration _configuration;

        public AppDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = configuration.GetConnectionString("DBConnection");
            var mongoUrl= MongoUrl.Create(connectionString);
            var mongoClient=new MongoClient(mongoUrl);
            _mongoDatabase = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<UserRegistration> UserRegistrations => _mongoDatabase.GetCollection<UserRegistration>("userregistration");
        public IMongoCollection<CustomerMaster> CustomerMasters => _mongoDatabase.GetCollection<CustomerMaster>("customermaster");
        public IMongoCollection<InvoiceMaster> Invoices => _mongoDatabase.GetCollection<InvoiceMaster>("invoicemaster");
    }
}
