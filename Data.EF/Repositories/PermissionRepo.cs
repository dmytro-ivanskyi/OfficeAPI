using Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    class PermissionRepo : IPermissionRepo
    {
        private readonly DataContext _dataContext;

        PermissionRepo(DataContext data)
        {
            _dataContext = data;
        }

        async Task<List<Permission>> GetPermissionsAsync()
        {
            return await _dataContext.Permissions.ToListAsync();
        }

        async Task<Permission> GetPermissionByIdAsync(Guid permissionId)
        {
            var perm = await _dataContext.Permissions.SingleOrDefaultAsync(x => x.Id == permissionId);

            return perm;
        }

        async Task<bool> CreatePermissionAsync(Permission permission)
        {
            await _dataContext.Permissions.AddAsync(permission);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        async Task<bool> UpdatePermissionAsync(Permission permissionToUpdate)
        {
            _dataContext.Permissions.Update(permissionToUpdate);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        async Task<bool> DeletePermissionAsync(Guid permissionId)
        {
            var permission = await _dataContext.Permissions.SingleOrDefaultAsync(x => x.Id == permissionId);

            if (permission == null)
                return false;

            _dataContext.Permissions.Remove(permission);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
