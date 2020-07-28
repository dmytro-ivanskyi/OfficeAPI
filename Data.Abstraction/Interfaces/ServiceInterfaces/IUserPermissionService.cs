using Data.EF.Models;
using System.Threading.Tasks;

namespace Data.Abstraction.Interfaces.ServiceInterfaces
{
    public interface IUserPermissionService
    {
        Task<bool> CreateUserPermissionAsync(UserPermission userPermission);
    }
}
