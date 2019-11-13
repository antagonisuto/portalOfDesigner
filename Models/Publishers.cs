using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Publishers
    {
        [Key]
        public int Pub_id { get; set; }
        public string Pub_name { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
