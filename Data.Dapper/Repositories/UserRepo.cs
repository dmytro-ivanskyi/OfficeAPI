using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class UserRepo : IUserRepo
    {
        public Task<bool> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdShortAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(User userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
