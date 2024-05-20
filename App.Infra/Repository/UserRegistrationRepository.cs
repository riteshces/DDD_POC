using App.Domain.Entity;
using App.Domain.Repository;
using App.Infra.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Repository
{
    public class UserRegistrationRepository : IUserRegistartion
    {
        private readonly AppDBContext _appDBContext;

        public UserRegistrationRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }


        public async Task<UserRegistration> AddUserAsync(UserRegistration userRegistration)
        {
            #region User name & Email Id duplication validation
            var filter = Builders<UserRegistration>.Filter.Eq(u => u.UserName, userRegistration.UserName);
            var user = await _appDBContext.UserRegistrations.FindAsync(filter).Result.FirstOrDefaultAsync();
            if (user is not null)
            {
                throw new Exception("Username already exists.");
            }

            filter = Builders<UserRegistration>.Filter.Eq(u => u.EmailId, userRegistration.EmailId);
            user = await _appDBContext.UserRegistrations.FindAsync(filter).Result.FirstOrDefaultAsync();
            if (user is not null)
            {
                throw new Exception("Email Id already exists.");
            }
            #endregion

            await _appDBContext.UserRegistrations.InsertOneAsync(userRegistration);
            return userRegistration;
        }

        public async Task<UserRegistration> GetByIdAsync(string id)
        {
            var filter = Builders<UserRegistration>.Filter.Eq(u => u.Id, id);
            var user=await _appDBContext.UserRegistrations.FindAsync(filter).Result.FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserRegistration> UpdateUserAsync(string id, UserRegistration userRegistration)
        {
            var filter = Builders<UserRegistration>.Filter.Eq(u => u.Id, id);
            var userEntity = Builders<UserRegistration>.Update
                .Set(u => u.Name, userRegistration.Name)
                .Set(u => u.ContactNo, userRegistration.ContactNo);

            var result = _appDBContext.UserRegistrations.UpdateOneAsync(filter, userEntity);
            var user = await _appDBContext.UserRegistrations.FindAsync(filter).Result.FirstOrDefaultAsync();
            return user;
        }
    }
}
