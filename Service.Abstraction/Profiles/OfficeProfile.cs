using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.ResponseModels;

namespace Service.Abstraction.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeResponse>().ReverseMap();
        }
    }
}
