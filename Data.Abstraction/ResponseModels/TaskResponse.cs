using System;

namespace Data.Abstraction.ResponseModels
{
    public class TaskResponse
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
