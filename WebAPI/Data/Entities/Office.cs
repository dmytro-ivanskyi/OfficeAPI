using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public List<User> Users { get; set; }
    }
}
