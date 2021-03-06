﻿using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
{
    public interface IOfficeService
    {
        Task<List<OfficeResponse>> GetOfficesAsync();

        Task<OfficeResponse> GetOfficeByIdAsync(Guid officeId);

        Task<OfficeWithUsersResponse> GetOfficeByIdWithUsersAsync(Guid officeId);

        Task<OfficeResponse> UpdateOfficeAsync(Guid officeId , UpdateOfficeRequest officeToUpdate);

        Task<bool> DeleteOfficeAsync(Guid officeId);

        Task<OfficeResponse> CreateOfficeAsync(CreateOfficeRequest office);
    }
}
