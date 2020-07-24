using System.ComponentModel.DataAnnotations;

namespace WebAPI.Contracts.V1.Requests
{
    public class CreateOfficeRequest
    {
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
