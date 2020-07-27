using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IPermissionService
    {
        Task<List<Permission>> GetPermissions();

        Task<Permission> GetPermissionById(Guid permissionId);

        Task<bool> CreatePermission(Permission permission);

        Task<bool> UpdatePermission(Permission permissionToUpdate);

        Task<bool> DeletePermission(Guid permissionId);
    }
}
