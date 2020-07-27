using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserSQLRepo _userSQLRepo;

        public UserService(IUserSQLRepo userSQLRepo)
        {
            _userSQLRepo = userSQLRepo;
        }

        public async Task<bool> CreateUser(User user)
        {
            return await _userSQLRepo.CreateUser(user);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            return await _userSQLRepo.DeleteUser(userId);
        }  

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userSQLRepo.GetUserById(userId);
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            return await _userSQLRepo.GetUsers();
        }

        public async Task<bool> UpdateUser(User userToUpdate)
        {
            return await _userSQLRepo.UpdateUser(userToUpdate);
        }
    }
}
