using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Data.Abstraction.Models;
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

        public async Task<bool> CreateUserAsync(User user)
        {
            return await _userRepo.CreateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepo.DeleteUserAsync(userId);
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _userRepo.GetUserByIdAsync(userId);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepo.GetUsersAsync();
        }

        public async Task<bool> UpdateUserAsync(User userToUpdate)
        {
            return await _userRepo.UpdateUserAsync(userToUpdate);
        }
    }
}
