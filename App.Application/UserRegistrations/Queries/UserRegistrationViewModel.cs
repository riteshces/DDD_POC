using App.Application.Common.Mappings;
using App.Domain.Entity;

namespace App.Application.UserRegistrations.Queries
{
    public class UserRegistrationViewModel:IMapFrom<UserRegistration>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
    }
}
