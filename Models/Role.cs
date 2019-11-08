using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Role
    {
        [Key]
        public int Role_id { get; set; }
        public string Name { get; set; }

        public List<Users> Users { get; set; }
        public List<Designers> Designers { get; set; }
        public List<Customers> Customers { get; set; }
    }
}
