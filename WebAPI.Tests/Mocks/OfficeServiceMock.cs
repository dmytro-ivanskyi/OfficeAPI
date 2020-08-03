using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                Name = "Headquarter"
            },
            new OfficeResponse
            {
                Id = Guid.Parse("B13C61AE-8137-4F15-AFFD-08D8330112C0"),
                Name = "Second Office"
            }
        };

        public List<OfficeResponse> Response { get 
            {
                return testData;
            } 
        }

        public async Task<List<OfficeResponse>> GetOfficesAsync()
        {
            return await Task.FromResult(Response);
        }

        public async Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId)
        {
            return await Task.FromResult(Response.Find(x => x.Id == officeId));
        }

        public async Task<OfficeResponse> CreateOfficeAsync(CreateOfficeRequest office)
        {
            if (office.Name == string.Empty)
                return null;
                
            var newOffice = new OfficeResponse
            {
                Id = Guid.NewGuid(),
                Name = office.Name
            };
            
            return await Task.FromResult(newOffice);
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            return await Task.FromResult(Response.Exists(x => x.Id == officeId));
        }

        public async Task<OfficeWithUsersResponse> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            var office = new OfficeWithUsersResponse
            {
                Id = officeId,
                Name = Response.First().Name,
                Users = new List<UserShortResponse> 
                { 
                    new UserShortResponse
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "John",
                        LastName = "Smith",
                        Age = 33
                    },
                    new UserShortResponse
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Bob",
                        LastName = "Can",
                        Age = 34
                    }
                }
            };

            return await Task.FromResult(office);
        }
        
        

        public async Task<OfficeResponse> UpdateOfficeAsync(Guid officeId, UpdateOfficeRequest officeToUpdate)
        {
            var updatedOffice = Response.Find(x => x.Id == officeId);

            if (updatedOffice == null)
                return null;

            updatedOffice.Name = officeToUpdate.Name;

            return await Task.FromResult(updatedOffice);
        }
    }
}
