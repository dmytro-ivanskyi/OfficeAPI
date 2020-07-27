using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetUsers();

        Task<User> GetUserById(Guid userId);

        Task<bool> UpdateUser(User userToUpdate);

        Task<bool> DeleteUser(Guid userId);

        Task<bool> CreateUser(User user);
    }
}
