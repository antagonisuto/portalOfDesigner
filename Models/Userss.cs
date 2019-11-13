using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Userss
    {
        [Key]
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }


        [ForeignKey("Role")]
        public int Role_id { get; set; }
        public Roles Role { get; set; }

        public ICollection<BooksRequests> BooksRequests { get; set; }
        public ICollection<BooksInventory> BooksInventories { get; set; }
    }
}
