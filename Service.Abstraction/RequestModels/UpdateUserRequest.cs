using System;

namespace Service.Abstraction.RequestModels
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Guid OfficeId { get; set; }
    }
}
