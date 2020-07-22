using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services
{
    public interface IOfficeService
    {
        List<Office> GetOffices();
        Office GetOfficeById(Guid officeId);

        bool UpdateOffice(Office officeToUpdate);

        bool DeleteOffice(Guid officeId);
    }
}
