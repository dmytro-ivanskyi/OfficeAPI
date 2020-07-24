using System;
using System.Collections.Generic;
using WebAPI.Data.Entities;

namespace WebAPI.Contracts.V1.Responses
{
    public class OfficeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
