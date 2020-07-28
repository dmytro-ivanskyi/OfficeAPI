using Data.EF.Models;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    class UserPermissionRepo : IUserPermissionRepo
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
