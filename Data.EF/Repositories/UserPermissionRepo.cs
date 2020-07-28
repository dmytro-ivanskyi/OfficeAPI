using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Models;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class UserPermissionRepo : IUserPermissionRepo
    {
        private readonly DataContext _dataContext;

        public UserPermissionRepo(DataContext data)
        {
            _dataContext = data;
        }
        public async Task<bool> CreateUserPermissionAsync(UserPermission userPermission)
        {
            await _dataContext.UserPermissions.AddAsync(userPermission);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
