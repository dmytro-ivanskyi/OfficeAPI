using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IUserPermissionService
    {
        Task<bool> CreateUserPermission(UserPermission userPermission);
    }
}
