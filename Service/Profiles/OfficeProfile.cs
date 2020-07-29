using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System.Linq;

namespace Service.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            // For GET requests
            CreateMap<Office, OfficeResponse>();
            CreateMap<Office, OfficeWithUsersResponse>().ForMember(dest => dest.Users, opt => 
            opt.MapFrom(scr => scr.Users.Select(x => new UserShortResponse 
            { 
                Id = x.Id, 
                FirstName = x.FirstName, 
                LastName = x.LastName, 
                Age = x.Age 
            })));

            // For PUT and POST
            CreateMap<UpdateOfficeRequest, Office>();
            CreateMap<CreateOfficeRequest, Office>();
        }
    }
}
