using Service.Abstraction.ResponseModels;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
{
    public interface IUserPermissionService
    {
        Task<bool> CreateUserPermissionAsync(UserPermissionResponse userPermission);
    }
}
