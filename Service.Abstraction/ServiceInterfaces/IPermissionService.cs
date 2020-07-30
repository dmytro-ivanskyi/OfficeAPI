using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
{
    public interface IPermissionService
    {
        Task<List<PermissionResponse>> GetPermissionsAsync();

        Task<PermissionResponse> GetPermissionByIdAsync(Guid permissionId);

        Task<PermissionResponse> CreatePermissionAsync(CreatePermissionRequest permission);

        Task<PermissionResponse> UpdatePermissionAsync(Guid permissionId, UpdatePermissionRequest permissionToUpdate);

        Task<bool> DeletePermissionAsync(Guid permissionId);
    }
}
