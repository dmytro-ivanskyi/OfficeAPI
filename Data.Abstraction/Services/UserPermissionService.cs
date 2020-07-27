using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionSQLRepo _userPermissionSQLRepo;

        public UserPermissionService(IUserPermissionSQLRepo userPermission)
        {
            _userPermissionSQLRepo = userPermission;
        }

        public async Task<bool> CreateUserPermission(UserPermission userPermission)
        {
            return await _userPermissionSQLRepo.CreateUserPermission(userPermission);
        }
    }
}
