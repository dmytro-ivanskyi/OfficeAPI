using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.ResponseModels;

namespace Data.Abstraction.Profiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
