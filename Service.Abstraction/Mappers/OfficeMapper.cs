using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.Mappers.MapperInterfaces;
using Service.Abstraction.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Abstraction.Mappers
{
    public class OfficeMapper : IOfficeMapper
    {
        private readonly IMapper _mapper;
        public OfficeMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<OfficeResponse> MapOfficeList(List<Office> offices)
        {
            return _mapper.Map<List<OfficeResponse>>(offices);
        }

        public OfficeResponse MapOffice(Office office)
        {
            return _mapper.Map<OfficeResponse>(office);
        }
    }
}
