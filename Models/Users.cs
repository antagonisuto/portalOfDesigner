using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Users
    {
        [Key]
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Full_name { get; set; }

        public int Role_id { get; set; }
        public Role Role { get; set; }

        public List<Designers> Designers { get; set; }
        public List<Customers> Customers { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Requests> Requests { get; set; }
    }
}
