using System;
using System.Collections.Generic;

namespace Service.Abstraction.ResponseModels
{
    public class UserFullResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Guid OfficeId { get; set; }
         
        public IEnumerable<TaskResponse> Tasks { get; set; }
    }
}
