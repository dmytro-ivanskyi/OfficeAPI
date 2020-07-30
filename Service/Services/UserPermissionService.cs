using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepo _userPermissionRepo;

        public UserPermissionService(IUserPermissionRepo userPermission)
        {
            _userPermissionRepo = userPermission;
        }

        public async Task<bool> AsignUserPermissionAsync(Guid permissionId, Guid userId)
        {
            var newUserPermission = new UserPermission
            {
                UserId = userId,
                PermissionId = permissionId
            };

            return await _userPermissionRepo.AsignUserPermissionAsync(newUserPermission);
        }
    }
}
