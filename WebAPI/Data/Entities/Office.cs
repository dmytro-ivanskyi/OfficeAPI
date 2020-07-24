using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebAPI.Data.Entities
{
    public class Office
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
