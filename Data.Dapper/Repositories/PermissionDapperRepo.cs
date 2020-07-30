using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class PermissionDapperRepo : IPermissionRepo
    {
        public Task<bool> CreatePermissionAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePermissionAsync(Guid permissionId)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetPermissionByIdAsync(Guid permissionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permission>> GetPermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePermissionAsync(Permission permissionToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
