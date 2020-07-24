using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Entities
{
    public class UserTask
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
