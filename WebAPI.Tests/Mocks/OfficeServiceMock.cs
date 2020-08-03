using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Tests.Mocks
{
    public class OfficeServiceMock : IOfficeService
    {
        private readonly List<OfficeResponse> testData = new List<OfficeResponse>
        {
            new OfficeResponse
            {
                Id = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650"),
                Name = "Headquerter"
            },
            new OfficeResponse
            {
                Id = Guid.Parse("B13C61AE-8137-4F15-AFFD-08D8330112C0"),
                Name = "Second Office"
            }
        };

        public List<OfficeResponse> Responses { get 
            {
                return testData;
            } 
        }

        public async Task<List<OfficeResponse>> GetOfficesAsync()
        {
            return await Task.FromResult(Responses);
        }

        public async Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId)
        {
            return await Task.FromResult(Responses.Find(x => x.Id == officeId));
        }

        public Task<OfficeResponse> CreateOfficeAsync(CreateOfficeRequest office)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            return await Task.FromResult(true);
        }

        public Task<OfficeWithUsersResponse> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            throw new NotImplementedException();
        }

        

        public Task<OfficeResponse> UpdateOfficeAsync(Guid officeId, UpdateOfficeRequest officeToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
