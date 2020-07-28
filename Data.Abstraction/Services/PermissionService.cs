using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepo _permissionRepo;

        public PermissionService(IPermissionRepo repo)
        {
            _permissionRepo = repo;
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            return await _permissionRepo.GetPermissionsAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(Guid permissionId)
        {
            return await _permissionRepo.GetPermissionByIdAsync(permissionId);
        }

        public async Task<bool> CreatePermissionAsync(Permission permission)
        {
            return await _permissionRepo.CreatePermissionAsync(permission);
        }

        public async Task<bool> UpdatePermissionAsync(Permission permissionToUpdate)
        {
            return await _permissionRepo.UpdatePermissionAsync(permissionToUpdate);
        }

        public async Task<bool> DeletePermissionAsync(Guid permissionId)
        {
            return await _permissionRepo.DeletePermissionAsync(permissionId);
        }
    }
}
