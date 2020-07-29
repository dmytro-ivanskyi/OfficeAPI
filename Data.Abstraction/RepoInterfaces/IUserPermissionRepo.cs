﻿using Data.Abstraction.Models;
using System.Threading.Tasks;

namespace Data.Abstraction.RepoInterfaces
{
    public interface IUserPermissionRepo
    {
        Task<bool> CreateUserPermissionAsync(UserPermission userPermission);
    }
}