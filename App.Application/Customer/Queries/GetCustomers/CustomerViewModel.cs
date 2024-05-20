using App.Application.Common.Mappings;
using App.Domain.Entity;

namespace App.Application.Customer.Queries.GetCustomers
{
    public class CustomerViewModel : IMapFrom<CustomerMaster>
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
    }
}
