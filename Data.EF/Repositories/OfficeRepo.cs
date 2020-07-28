using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class OfficeRepo : IOfficeRepo
    {
        private readonly DataContext _dataContext;

        public OfficeRepo(DataContext data)
        {
            _dataContext = data;
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            return await _dataContext.Offices.ToListAsync();
        }

        public async Task<Office> GetOfficeByIdAsync(Guid officeId)
        {
            return await _dataContext.Offices.SingleOrDefaultAsync(x => x.Id == officeId);
        }

        public async Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            var officeUsers = await _dataContext.Offices
                .Include(of => of.Users)
                .SingleOrDefaultAsync(x => x.Id == officeId);
            return officeUsers;
        }

        public async Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {
            _dataContext.Offices.Update(officeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            var office = await GetOfficeByIdAsync(officeId);

            if (office == null)
                return false;

            _dataContext.Offices.Remove(office);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CreateOfficeAsync(Office office)
        {
            await _dataContext.Offices.AddAsync(office);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
