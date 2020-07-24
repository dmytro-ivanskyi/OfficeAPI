using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IPermissionService
    {
        Task<List<PermissionResponse>> GetPermissions();

        Task<PermissionResponse> GetPermissionById(Guid permissionId);

        Task<bool> CreatePermission(Permission permission);

        Task<bool> UpdatePermission(Permission permissionToUpdate);

        Task<bool> DeletePermission(Guid permissionId);
    }
}
