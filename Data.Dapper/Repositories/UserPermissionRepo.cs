using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class UserPermissionRepo : IUserPermissionRepo
    {
        public Task<bool> AsignUserPermissionAsync(UserPermission userPermission)
        {
            throw new System.NotImplementedException();
        }
    }
}
