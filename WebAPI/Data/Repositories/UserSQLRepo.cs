using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;

namespace WebAPI.Data.Repositories
{
    public class UserSQLRepo : IUserSQLRepo
    {
        private readonly DataContext _dataContext;

        public UserSQLRepo(DataContext data)
        {
            _dataContext = data;
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            return await _dataContext.Users
                .Select(x => new UserResponse
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    OfficeId = x.OfficeId
                })
                .ToListAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            var user = await _dataContext.Users
                .Include(u => u.Tasks)
                .SingleOrDefaultAsync(x => x.Id == userId);
            await _dataContext.Entry(user).Collection(user => user.Permissions).LoadAsync();
            //await _dataContext.UserPermissions.Where(x => x.UserId == userId).LoadAsync();

            return user;
        }

        public async Task<bool> UpdateUser(User userToUpdate)
        {
            _dataContext.Users.Update(userToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var user = await GetUserById(userId);

            if (user == null)
                return false;

            _dataContext.Users.Remove(user);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CreateUser(User user)
        {
            await _dataContext.Users.AddAsync(user);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
