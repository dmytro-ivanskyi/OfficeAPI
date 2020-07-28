using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.ResponseModels;

namespace Data.Abstraction.Profiles
{
    class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeResponse>();
        }
    }
}
