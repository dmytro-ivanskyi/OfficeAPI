using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> CreateUserAsync(UserResponse user)
        {
            throw new NotImplementedException();
            //return await _userRepo.CreateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepo.DeleteUserAsync(userId);
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
            //return await _userRepo.GetUserByIdAsync(userId);
        }

        public async Task<List<UserResponse>> GetUsersAsync()
        {
            throw new NotImplementedException();
            //return await _userRepo.GetUsersAsync();
        }

        public async Task<bool> UpdateUserAsync(UserResponse userToUpdate)
        {
            throw new NotImplementedException();
            //return await _userRepo.UpdateUserAsync(userToUpdate);
        }
    }
}
