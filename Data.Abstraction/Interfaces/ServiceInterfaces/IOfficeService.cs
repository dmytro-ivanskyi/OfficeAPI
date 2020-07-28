using Data.Abstraction.Models;
using Data.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Interfaces.ServiceInterfaces
{
    public interface IOfficeService
    {
        Task<List<OfficeResponse>> GetOfficesAsync();

        Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId);

        Task<OfficeResponse> GetOfficeByIdWithUsersAsync(Guid officeId);

        Task<bool> UpdateOfficeAsync(Office officeToUpdate);

        Task<bool> DeleteOfficeAsync(Guid officeId);

        Task<bool> CreateOfficeAsync(Office office);
    }
}
