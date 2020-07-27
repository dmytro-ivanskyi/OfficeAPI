using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeSQLRepo _officeSQLRepo;

        public OfficeService(IOfficeSQLRepo officeSQLRepo)
        {
            _officeSQLRepo = officeSQLRepo;
        }

        public async Task<List<OfficeResponse>> GetOffices()
        {
            return await _officeSQLRepo.GetOffices();
        }

        public async Task<Office> GetOfficeById(Guid officeId)
        {
            return await _officeSQLRepo.GetOfficeById(officeId);
        }

        public async Task<Office> GetOfficeByIdWithUsers(Guid officeId)
        {
            return await _officeSQLRepo.GetOfficeByIdWithUsers(officeId);
        }

        public async Task<bool> UpdateOffice(Office officeToUpdate)
        {

            return await _officeSQLRepo.UpdateOffice(officeToUpdate);
        }

        public async Task<bool> DeleteOffice(Guid officeId)
        {
            return await _officeSQLRepo.DeleteOffice(officeId);
        }

        public async Task<bool> CreateOffice(Office office)
        {
            return await _officeSQLRepo.CreateOffice(office);
        }
    }
}
