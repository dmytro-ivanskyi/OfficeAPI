using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IUserPermissionService
    {
        Task<bool> CreateUserPermission(UserPermission userPermission);
    }
}
