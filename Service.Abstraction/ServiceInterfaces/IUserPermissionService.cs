using System;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
{
    public interface IUserPermissionService
    {
        Task<bool> AsignUserPermissionAsync(Guid permissionId, Guid UserId);
    }
}