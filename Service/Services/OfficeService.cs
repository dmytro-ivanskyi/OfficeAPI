using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.Mappers.MapperInterfaces;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;

namespace Service.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepo _officeRepo;
        private readonly IOfficeMapper _mapper;

        public OfficeService(IOfficeRepo officeRepo)
        {
            _officeRepo = officeRepo;
        }

        public async Task<List<OfficeResponse>> GetOfficesAsync()
        {
            var offices = await _officeRepo.GetOfficesAsync();

            return MapOfficeList(offices);
        }

        public async Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId)
        { 
            var office = await _officeRepo.GetOfficeByIdAsync(officeId);


            return _mapper.MapOffice(office);
        }

        public async Task<OfficeResponse> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            var office = await _officeRepo.GetOfficeByIdWithUsersAsync(officeId);

            return _mapper.MapOffice(office);
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
