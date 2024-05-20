using App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repository
{
    public interface IUserRegistartion
    {
        Task<UserRegistration> GetByIdAsync(string id);
        Task<UserRegistration> AddUserAsync(UserRegistration userRegistration);
        Task<UserRegistration> UpdateUserAsync(string id, UserRegistration userRegistration);
    }
}
