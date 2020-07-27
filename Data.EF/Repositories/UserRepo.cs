using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    class UserRepo : IUserRepo
    {
        private readonly DataContext _dataContext;

        public UserRepo(DataContext data)
        {
            _dataContext = data;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await _dataContext.Users
                .Include(u => u.Tasks)
                .SingleOrDefaultAsync(x => x.Id == userId);

            await _dataContext.Entry(user).Collection(user => user.Permissions).LoadAsync();

            return user;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateUserAsync(User userToUpdate)
        {
            _dataContext.Users.Update(userToUpdate);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);

            if (user == null)
                return false;

            _dataContext.Users.Remove(user);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        
    }
}
