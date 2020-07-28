using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Data.Abstraction.Models;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepo _userPermissionRepo;

        public UserPermissionService(IUserPermissionRepo userPermission)
        {
            _userPermissionRepo = userPermission;
        }

        public async Task<bool> CreateUserPermissionAsync(UserPermission userPermission)
        {
            return await _userPermissionRepo.CreateUserPermissionAsync(userPermission);
        }
    }
}
