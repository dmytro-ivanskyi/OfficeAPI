using AutoMapper;
using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Data.Abstraction.Models;
using Data.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepo _officeRepo;
        private readonly IMapper _mapper;

        public OfficeService(IOfficeRepo officeRepo, IMapper mapper)
        {
            _officeRepo = officeRepo;
            _mapper = mapper;
        }

        public async Task<List<OfficeResponse>> GetOfficesAsync()
        {
            var offices = await _officeRepo.GetOfficesAsync();

            List<OfficeResponse> officeResponseList = _mapper.Map<List<OfficeResponse>>(offices);

            return officeResponseList;
        }

        public async Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId)
        { 
            var office = await _officeRepo.GetOfficeByIdAsync(officeId);

            OfficeResponse officeResponse = _mapper.Map<OfficeResponse>(office);

            return officeResponse;
        }

        public async Task<OfficeResponse> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            var office = await _officeRepo.GetOfficeByIdWithUsersAsync(officeId);

            OfficeResponse officeResponse = _mapper.Map<OfficeResponse>(office);

            return officeResponse;
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
