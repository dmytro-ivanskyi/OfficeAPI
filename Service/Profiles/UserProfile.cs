using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;

namespace Data.Profiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<User, UserShortResponse>();

            CreateMap<CreateUserRequest ,User>();
            CreateMap<UpdateUserRequest ,User>();
        }
    }
}
