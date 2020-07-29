using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System.Linq;

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
            })));

            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
