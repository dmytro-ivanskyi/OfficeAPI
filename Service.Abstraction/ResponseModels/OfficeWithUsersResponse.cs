using System;
using System.Collections.Generic;

namespace Service.Abstraction.ResponseModels
{
    public class OfficeWithUsersResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserShortResponse> Users { get; set; }
       
    }
}
