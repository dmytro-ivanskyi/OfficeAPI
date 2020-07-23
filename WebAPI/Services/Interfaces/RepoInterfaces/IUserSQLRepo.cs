using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{
    public interface IUserSQLRepo
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserById(Guid userId);

        Task<bool> UpdateUser(User userToUpdate);

        Task<bool> DeleteUser(Guid officeId);

        Task<bool> CreateUser(User user);
    }
}
