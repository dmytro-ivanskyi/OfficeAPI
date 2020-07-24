using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{ 
    public interface IOfficeSQLRepo
    {
        Task<List<OfficeResponse>> GetOffices();

        Task<Office> GetOfficeById(Guid officeId);

        Task<Office> GetOfficeByIdWithUsers(Guid officeId);

        Task<bool> UpdateOffice(Office officeToUpdate);

        Task<bool> DeleteOffice(Guid officeId);

        Task<bool> CreateOffice(Office office);
    }
}
