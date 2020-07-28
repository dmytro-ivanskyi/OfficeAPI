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

        Task<bool> CreatePermissionAsync(PermissionResponse permission);

        Task<bool> UpdatePermissionAsync(PermissionResponse permissionToUpdate);

        Task<bool> DeletePermissionAsync(Guid permissionId);
    }
}
