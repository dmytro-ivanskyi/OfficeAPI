using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepo _permissionRepo;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepo repo, IMapper mapper)
        {
            _permissionRepo = repo;
            _mapper = mapper;
        }

        public async Task<List<PermissionResponse>> GetPermissionsAsync()
        {
            var permissions = await _permissionRepo.GetPermissionsAsync();
            return _mapper.Map<List<PermissionResponse>>(permissions);
        }

        public async Task<PermissionResponse> GetPermissionByIdAsync(Guid permissionId)
        {
           var permission = await _permissionRepo.GetPermissionByIdAsync(permissionId);

            return _mapper.Map<PermissionResponse>(permission);
        }

        public async Task<PermissionResponse> CreatePermissionAsync(CreatePermissionRequest permission)
        {
            var newPermission = _mapper.Map<Permission>(permission);

            var created = await _permissionRepo.CreatePermissionAsync(newPermission);

            if (!created)
                return null;

            return await GetPermissionByIdAsync(newPermission.Id);
        }

        public async Task<PermissionResponse> UpdatePermissionAsync(Guid permissionId, UpdatePermissionRequest permissionToUpdate)
        {
            var updatedPermission = _mapper.Map<Permission>(permissionToUpdate);
            updatedPermission.Id = permissionId;

            var updated = await _permissionRepo.UpdatePermissionAsync(updatedPermission);

            if (updated)
                return await GetPermissionByIdAsync(updatedPermission.Id);

            return null;
        }

        public async Task<bool> DeletePermissionAsync(Guid permissionId)
        {
            return await _permissionRepo.DeletePermissionAsync(permissionId);
        }
    }
}