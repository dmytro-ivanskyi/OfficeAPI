﻿using Data.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.RepoInterfaces
{
    public interface IOfficeRepo
    {
        Task<List<Office>> GetOfficesAsync();

        Task<Office> GetOfficeByIdAsync(Guid officeId);

        Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId);

        Task<bool> UpdateOfficeAsync(Office officeToUpdate);

        Task<bool> DeleteOfficeAsync(Guid officeId);

        Task<bool> CreateOfficeAsync(Office office);
    }
}
