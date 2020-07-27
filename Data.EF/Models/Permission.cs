using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.EF.Models
{
    public class Permission
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserPermission> Permissions { get; set; }
    }
}
