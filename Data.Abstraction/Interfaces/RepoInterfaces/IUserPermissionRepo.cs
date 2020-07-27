using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{
    public interface IUserPermissionRepo
    {
        Task<bool> CreateUserPermission(UserPermission userPermission);
    }
}
