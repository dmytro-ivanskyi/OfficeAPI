using System.ComponentModel.DataAnnotations;

namespace WebAPI.Contracts.V1.Requests
{
    public class UpdatePermissionRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
