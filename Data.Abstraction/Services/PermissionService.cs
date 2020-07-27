using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionSQLRepo _permissionSQLRepo;

        public PermissionService(IPermissionSQLRepo repo)
        {
            _permissionSQLRepo = repo;
        }
        public async Task<List<PermissionResponse>> GetPermissions()
        {
            return await _permissionSQLRepo.GetPermissions();
        }

        public async Task<PermissionResponse> GetPermissionById(Guid permissionId)
        {
            return await _permissionSQLRepo.GetPermissionById(permissionId);
        }

        public async Task<bool> CreatePermission(Permission permission)
        {
            return await _permissionSQLRepo.CreatePermission(permission);
        }

        public async Task<bool> UpdatePermission(Permission permissionToUpdate)
        {
            return await _permissionSQLRepo.UpdatePermission(permissionToUpdate);
        }

        public async Task<bool> DeletePermission(Guid permissionId)
        {
            return await _permissionSQLRepo.DeletePermission(permissionId);
        }
    }
}
