using System;

namespace Data.Abstraction.ResponseModels
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid OfficeId { get; set; }
    }
}
