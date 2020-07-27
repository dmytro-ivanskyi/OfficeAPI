using System;
using System.ComponentModel.DataAnnotations;

namespace Data.EF.Models
{
    public class UserTask
    {
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
