using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class States
    {
        [Key]
        public int State_id { get; set; }
        public string Name { get; set; }

        public List<Orders> Orders { get; set; }
        public List<Requests> Request { get; set; }
    }
}
