using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.RequestModels;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> GetUsersAsync()
        {

            var users = await _userRepo.GetUsersAsync();

            return _mapper.Map<List<UserResponse>>(users);
        }

        public async Task<UserFullResponse> CreateUserAsync(CreateUserRequest user)
        {
            var newUser = _mapper.Map<User>(user);

            var created = await _userRepo.CreateUserAsync(newUser);

            if (!created)
                return null;

            return await GetUserByIdAsync(newUser.Id);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepo.DeleteUserAsync(userId);
        }

        public async Task<UserFullResponse> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepo.GetUserByIdAsync(userId);

            return _mapper.Map<UserFullResponse>(user);
        }

        public async Task<UserResponse> GetUserByIdShortAsync(Guid userId)
        {
            var user = await _userRepo.GetUserByIdShortAsync(userId);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserFullResponse> UpdateUserAsync(Guid userId, UpdateUserRequest userToUpdate)
        {
            var updatedUser = _mapper.Map<User>(userToUpdate);
            updatedUser.Id = userId;

            var updated = await _userRepo.UpdateUserAsync(updatedUser);

            if(updated)
                return await GetUserByIdAsync(userId);

            return null;
        }
    }
}
