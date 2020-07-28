using Data.EF.Models;
using System.Threading.Tasks;

namespace Data.Abstraction.Interfaces.RepoInterfaces
{
    public interface IUserPermissionRepo
    {
        Task<bool> CreateUserPermissionAsync(UserPermission userPermission);
    }
}
