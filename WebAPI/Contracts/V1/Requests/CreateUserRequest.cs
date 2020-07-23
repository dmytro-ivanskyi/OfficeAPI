using System;
using System.Collections.Generic;
using WebAPI.Data.Entities;

namespace WebAPI.Contracts.V1.Requests
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Guid OfficeId { get; set; }
        //public List<UserTask> Tasks { get; set; }
    }
}
