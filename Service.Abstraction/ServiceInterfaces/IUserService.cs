﻿using Service.Abstraction.RequestModels;
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

        Task<UserFullResponse> GetUserFullByIdAsync(Guid userId);

        Task<UserResponse> UpdateUserAsync(Guid userId, UpdateUserRequest userToUpdate);

        Task<bool> DeleteUserAsync(Guid userId);

        Task<UserResponse> CreateUserAsync(CreateUserRequest user);
    }
}
