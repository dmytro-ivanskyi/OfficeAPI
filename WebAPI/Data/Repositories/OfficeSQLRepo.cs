﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;

namespace WebAPI.Data.Repositories
{
    public class OfficeSQLRepo : IOfficeSQLRepo
    {
        private readonly DataContext _dataContext;

        public OfficeSQLRepo(DataContext data)
        {
            _dataContext = data;
        }

        public async Task<List<Office>> GetOffices()
        {
            return await _dataContext.Offices.ToListAsync();
        }

        public async Task<Office> GetOfficeById(Guid officeId)
        {
            return await _dataContext.Offices.SingleOrDefaultAsync(x => x.Id == officeId);
        }

        public async Task<bool> UpdateOffice(Office officeToUpdate)
        {
            _dataContext.Offices.Update(officeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteOffice(Guid officeId)
        {
            var office = await GetOfficeById(officeId);

            if (office == null)
                return false;

            _dataContext.Offices.Remove(office);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CreateOffice(Office office)
        {
            await _dataContext.Offices.AddAsync(office);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}