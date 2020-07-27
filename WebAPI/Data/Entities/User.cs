using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Guid OfficeId { get; set; }

        public List<UserPermission> Permissions { get; set; }

        public List<UserTask> Tasks { get; set; }
    }
}
