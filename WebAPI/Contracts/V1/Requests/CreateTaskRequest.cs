using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Contracts.V1.Requests
{
    public class CreateTaskRequest
    {
        [Required( ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
