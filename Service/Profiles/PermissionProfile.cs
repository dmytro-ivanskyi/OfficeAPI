using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;

namespace Service.Profiles
{
    class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionResponse>();

            CreateMap<CreatePermissionRequest, Permission>();
            CreateMap<UpdatePermissionRequest, Permission>();
        }
    }
}
