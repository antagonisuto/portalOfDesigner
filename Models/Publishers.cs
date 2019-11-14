using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Publishers
    {
        [Key]
        public int Pub_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Pub_name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
