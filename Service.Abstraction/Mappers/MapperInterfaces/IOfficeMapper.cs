using Data.Abstraction.Models;
using Service.Abstraction.ResponseModels;
using System.Collections.Generic;

namespace Service.Abstraction.Mappers.MapperInterfaces
{
    public interface IOfficeMapper
    {
        List<OfficeResponse> MapOfficeList(List<Office> offices);

        OfficeResponse MapOffice(Office offices);
    }
}
