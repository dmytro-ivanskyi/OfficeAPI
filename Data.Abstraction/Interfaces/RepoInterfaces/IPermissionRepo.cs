using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{
    public interface IPermissionRepo
    {
        Task<List<Permission>> GetPermissions();

        Task<Permission> GetPermissionById(Guid permissionId);

        Task<bool> CreatePermission(Permission permission);

        Task<bool> UpdatePermission(Permission permissionToUpdate);

        Task<bool> DeletePermission(Guid permissionId);
    }
}
