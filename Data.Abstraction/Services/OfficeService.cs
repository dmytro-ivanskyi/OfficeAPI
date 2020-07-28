using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepo _officeRepo;

        public OfficeService(IOfficeRepo officeRepo)
        {
            _officeRepo = officeRepo;
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            return await _officeRepo.GetOfficesAsync();
        }

        public async Task<Office> GetOfficeByIdAsync(Guid officeId)
        { 
            return await _officeRepo.GetOfficeByIdAsync(officeId);
        }

        public async Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            return await _officeRepo.GetOfficeByIdWithUsersAsync(officeId);
        }

        public async Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {

            return await _officeRepo.UpdateOfficeAsync(officeToUpdate);
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            return await _officeRepo.DeleteOfficeAsync(officeId);
        }

        public async Task<bool> CreateOfficeAsync(Office office)
        {
            return await _officeRepo.CreateOfficeAsync(office);
        }
    }
}
