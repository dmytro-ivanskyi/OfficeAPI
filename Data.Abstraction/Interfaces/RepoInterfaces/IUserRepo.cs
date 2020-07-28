using Data.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Interfaces.RepoInterfaces
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(Guid userId);

        Task<bool> CreateUserAsync(User user);

        Task<bool> UpdateUserAsync(User userToUpdate);

        Task<bool> DeleteUserAsync(Guid userId);
    }
}
