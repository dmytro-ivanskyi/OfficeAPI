using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Contracts.V1.Responses
{
    public class OfficeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
