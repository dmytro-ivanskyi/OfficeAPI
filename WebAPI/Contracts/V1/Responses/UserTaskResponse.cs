using System;

namespace WebAPI.Contracts.V1.Responses
{
    public class UserTaskResponse
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
