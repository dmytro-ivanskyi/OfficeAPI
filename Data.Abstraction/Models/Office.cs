using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Abstraction.Models
{
    public class Office
    {
        public Office()
        {
            Users = new List<User>();
        }
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
