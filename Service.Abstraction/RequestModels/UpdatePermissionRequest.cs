using System.ComponentModel.DataAnnotations;

namespace Service.Abstraction.RequestModels
{
    public class UpdatePermissionRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
