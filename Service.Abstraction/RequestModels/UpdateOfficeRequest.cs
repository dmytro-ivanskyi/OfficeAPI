using System.ComponentModel.DataAnnotations;

namespace Service.Abstraction.RequestModels
{
    public class UpdateOfficeRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
