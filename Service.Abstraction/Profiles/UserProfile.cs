using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.ResponseModels;

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
