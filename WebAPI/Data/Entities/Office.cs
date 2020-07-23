using System;
using System.ComponentModel.DataAnnotations;
namespace WebAPI.Data.Entities
{
    public class Office
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
