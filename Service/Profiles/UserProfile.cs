using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

namespace Service.Profiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<User, UserShortResponse>();
            CreateMap<User, UserFullResponse>().ForMember(dest => dest.Tasks, opt =>
            opt.MapFrom(scr => scr.Tasks.Select(x => new TaskShortResponse
            {
                Id = x.Id,
                Description = x.Description
            }))).ForMember(dest => dest.Permissions, opt =>
            opt.MapFrom(src => src.Permissions.Select(x => new UserPermissionIdResponse
            {
                Id = x.PermissionId
            })));
            

            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
