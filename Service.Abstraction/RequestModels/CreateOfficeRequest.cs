using System.ComponentModel.DataAnnotations;

namespace Service.Abstraction.RequestModels
{
    public class CreateOfficeRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
