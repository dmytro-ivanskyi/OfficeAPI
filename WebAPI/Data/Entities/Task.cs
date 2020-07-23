using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public User User { get; set; }
    }
}
