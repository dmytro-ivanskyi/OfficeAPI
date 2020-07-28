using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetUsersAsync();

        Task<UserResponse> GetUserByIdAsync(Guid userId);

        Task<bool> UpdateUserAsync(UserResponse userToUpdate);

        Task<bool> DeleteUserAsync(Guid userId);

        Task<bool> CreateUserAsync(UserResponse user);
    }
}
