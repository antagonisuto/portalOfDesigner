using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Role_id { get; set; }

        [Required]
        [StringLength(20)]
        public string Role_name { get; set; }

        public virtual ICollection<Userss> Users { get; set; }
    }
}
