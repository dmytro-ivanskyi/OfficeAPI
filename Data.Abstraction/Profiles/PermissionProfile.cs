using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.ResponseModels;

namespace Data.Abstraction.Profiles
{
    class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionResponse>();
        }
    }
}
