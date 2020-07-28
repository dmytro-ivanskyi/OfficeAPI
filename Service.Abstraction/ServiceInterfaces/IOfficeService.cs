using Data.Abstraction.Models;
using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
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
