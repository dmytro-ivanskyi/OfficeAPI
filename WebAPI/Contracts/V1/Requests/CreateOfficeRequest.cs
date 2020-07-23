using System.ComponentModel.DataAnnotations;

namespace WebAPI.Contracts.V1.Requests
{
    public class CreateOfficeRequest
    {
        [Required(ErrorMessage = "Office must have a name")]
        public string Name { get; set; }
    }
}
