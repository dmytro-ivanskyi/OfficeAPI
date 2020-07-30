using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class OfficeRepo : IOfficeRepo
    {
        public Task<bool> CreateOfficeAsync(Office office)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            throw new NotImplementedException();
        }

        public Task<Office> GetOfficeByIdAsync(Guid officeId)
        {
            throw new NotImplementedException();
        }

        public Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Office>> GetOfficesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
.