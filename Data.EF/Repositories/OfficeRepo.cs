using Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    class OfficeSQLRepo : IOfficeRepo
    {
        private readonly DataContext _dataContext;

        OfficeSQLRepo(DataContext data)
        {
            _dataContext = data;
        }

        async Task<List<Office>> GetOfficesAsync()
        {
            return await _dataContext.Offices.ToListAsync();
        }

        async Task<Office> GetOfficeByIdAsync(Guid officeId)
        {
            return await _dataContext.Offices.SingleOrDefaultAsync(x => x.Id == officeId);
        }

        async Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            var officeUsers = await _dataContext.Offices
                .Include(of => of.Users)
                .SingleOrDefaultAsync(x => x.Id == officeId);
            return officeUsers;
        }

        async Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {
            _dataContext.Offices.Update(officeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            var office = await GetOfficeByIdAsync(officeId);

            if (office == null)
                return false;

            _dataContext.Offices.Remove(office);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        async Task<bool> CreateOfficeAsync(Office office)
        {
            await _dataContext.Offices.AddAsync(office);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
