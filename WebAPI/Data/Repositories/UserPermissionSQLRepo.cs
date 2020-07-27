using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;

namespace WebAPI.Data.Repositories
{
    public class UserPermissionSQLRepo : IUserPermissionSQLRepo
    {
        private readonly DataContext _dataContext;

        public UserPermissionSQLRepo(DataContext data)
        {
            _dataContext = data;
        }
        public async Task<bool> CreateUserPermission(UserPermission userPermission)
        {
            await _dataContext.UserPermissions.AddAsync(userPermission);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
