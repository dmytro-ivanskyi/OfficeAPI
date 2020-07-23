using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public List<Task> Tasks { get; set; }
        // public List<UserPermission> UserPermissions { get; set; }
    }
}
