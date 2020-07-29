using System;

namespace Service.Abstraction.ResponseModels
{
    public class TaskShortResponse
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}
