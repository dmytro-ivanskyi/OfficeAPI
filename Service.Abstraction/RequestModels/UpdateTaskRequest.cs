using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Abstraction.RequestModels
{
    public class UpdateTaskRequest
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
