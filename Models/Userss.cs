using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Userss
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        public string FullName { get; set; }

        public int Role_id { get; set; }

        [ForeignKey("Role_id")]
        public virtual Roles Role { get; set; }

        public virtual ICollection<BooksRequests> BooksRequests { get; set; }
        public virtual ICollection<BooksInventory> BooksInventories { get; set; }
    }
}
