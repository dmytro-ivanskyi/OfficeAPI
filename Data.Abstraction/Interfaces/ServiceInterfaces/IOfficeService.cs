using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface IOfficeService
    {
        Task<List<Office>> GetOffices();

        Task<Office> GetOfficeById(Guid officeId);
        Task<Office> GetOfficeByIdWithUsers(Guid officeId);

        Task<bool> UpdateOffice(Office officeToUpdate);

        Task<bool> DeleteOffice(Guid officeId);

        Task<bool> CreateOffice(Office office);
    }
}
