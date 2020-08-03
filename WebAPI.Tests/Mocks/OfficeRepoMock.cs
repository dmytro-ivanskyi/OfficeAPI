using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Tests.Mocks
{
    class OfficeRepoMock : IOfficeRepo
    {
        private readonly List<Office> testData = new List<Office>
        {
            new Office
            {
                Id = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650"),
                Name = "Headquarter"
            },
            new Office
            {
                Id = Guid.Parse("B13C61AE-8137-4F15-AFFD-08D8330112C0"),
                Name = "Second Office"
            }
        };

        public List<Office> Response
        {
            get
            {
                return testData;
            }
        }

        public Task<bool> CreateOfficeAsync(Office office)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Office> GetOfficeByIdAsync(Guid officeId)
        {
            return await Task.FromResult(Response.Find(x => x.Id == officeId));
        }

        public Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            return await Task.FromResult(Response);
        }

        public async Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {
           var updated =  Response.Find(x => x.Id == officeToUpdate.Id);
            if (updated == null)
                return await Task.FromResult(false);

            updated.Name = officeToUpdate.Name;
            return await Task.FromResult(true);
        }
    }
}
