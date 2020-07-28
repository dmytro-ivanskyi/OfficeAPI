using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class PermissionRepo : IPermissionRepo
    {
        private readonly DataContext _dataContext;

        public PermissionRepo(DataContext data)
        {
            _dataContext = data;
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            return await _dataContext.Permissions.ToListAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(Guid permissionId)
        {
            var perm = await _dataContext.Permissions.SingleOrDefaultAsync(x => x.Id == permissionId);

            return perm;
        }

        public async Task<bool> CreatePermissionAsync(Permission permission)
        {
            await _dataContext.Permissions.AddAsync(permission);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdatePermissionAsync(Permission permissionToUpdate)
        {
            _dataContext.Permissions.Update(permissionToUpdate);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePermissionAsync(Guid permissionId)
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
