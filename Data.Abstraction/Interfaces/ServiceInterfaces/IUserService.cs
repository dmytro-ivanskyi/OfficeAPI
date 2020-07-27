using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserById(Guid userId);

        Task<bool> UpdateUser(User userToUpdate);

        Task<bool> DeleteUser(Guid userId);

        Task<bool> CreateUser(User user);
    }
}
