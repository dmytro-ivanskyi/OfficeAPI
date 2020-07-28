using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    class UserPermissionRepo : IUserPermissionRepo
    {
        private readonly DataContext _dataContext;

        UserPermissionRepo(DataContext data)
        {
            _dataContext = data;
        }
        async Task<bool> CreateUserPermissionAsync(UserPermission userPermission)
        {
            await _dataContext.UserPermissions.AddAsync(userPermission);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
