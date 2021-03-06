﻿using Data.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.RepoInterfaces
{
    public interface IPermissionRepo
    {
        Task<List<Permission>> GetPermissionsAsync();

        Task<Permission> GetPermissionByIdAsync(Guid permissionId);

        Task<bool> CreatePermissionAsync(Permission permission);

        Task<bool> UpdatePermissionAsync(Permission permissionToUpdate);

        Task<bool> DeletePermissionAsync(Guid permissionId);
    }
}
