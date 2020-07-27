using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{
    public interface IUserPermissionSQLRepo
    {
        Task<bool> CreateUserPermission(UserPermission userPermission);
    }
}
