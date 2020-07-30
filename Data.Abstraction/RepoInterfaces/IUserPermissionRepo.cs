using Data.Abstraction.Models;
using System.Threading.Tasks;

namespace Data.Abstraction.RepoInterfaces
{
    public interface IUserPermissionRepo
    {
        Task<bool> AsignUserPermissionAsync(UserPermission userPermission);
    }
}
