using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;

namespace Service.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepo _officeRepo;
        private readonly IMapper _mapper ;

        public OfficeService(IOfficeRepo officeRepo, IMapper mapper)
        {
            _officeRepo = officeRepo;
            _mapper = mapper;
        }

        public async Task<List<OfficeResponse>> GetOfficesAsync()
        {
            var offices = await _officeRepo.GetOfficesAsync();

            return _mapper.Map<List<OfficeResponse>>(offices);
        }

        public async Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId)
        { 
            var office = await _officeRepo.GetOfficeByIdAsync(officeId);

            return _mapper.Map<OfficeResponse>(office);
        }

        public async Task<OfficeResponse> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            var office = await _officeRepo.GetOfficeByIdWithUsersAsync(officeId);

            return _mapper.Map<OfficeResponse>(office);
        }

        public async Task<OfficeResponse> UpdateOfficeAsync(Office officeToUpdate)
        {
            var updated = await _officeRepo.UpdateOfficeAsync(officeToUpdate);

            if (!updated)
                return null;

            return await GetOfficeByIdAsync(officeToUpdate.Id);
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            return await _officeRepo.DeleteOfficeAsync(officeId);
        }

        public async Task<OfficeResponse> CreateOfficeAsync(CreateOfficeRequest office)
        {
            var newOffice = _mapper.Map<Office>(office);

            var created = await _officeRepo.CreateOfficeAsync(newOffice);

            if (!created)
                return null;

            return await GetOfficeByIdAsync(newOffice.Id);
        }
    }
}
