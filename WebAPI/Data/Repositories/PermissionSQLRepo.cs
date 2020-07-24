using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;

namespace WebAPI.Data.Repositories
{
    public class PermissionSQLRepo : IPermissionSQLRepo
    {
        private readonly DataContext _dataContext;

        public PermissionSQLRepo(DataContext data)
        {
            _dataContext = data;
        }

        public async Task<List<PermissionResponse>> GetPermissions()
        {
            return await _dataContext.Permissions
                .Select(x => new PermissionResponse { 
                    Id = x.Id, 
                    Name = x.Name, 
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<PermissionResponse> GetPermissionById(Guid permissionId)
        {
            var perm = await _dataContext.Permissions.SingleOrDefaultAsync(x => x.Id == permissionId);

            return new PermissionResponse { Id = perm.Id, Name = perm.Name, Description = perm.Description };
        }

        public async Task<bool> CreatePermission(Permission permission)
        {
            await _dataContext.Permissions.AddAsync(permission);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdatePermission(Permission permissionToUpdate)
        {
            _dataContext.Permissions.Update(permissionToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePermission(Guid permissionId)
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
