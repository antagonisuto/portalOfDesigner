using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Designers
    {
        [Key]
        public int Designer_id { get; set; }
        public string Skills { get; set; }
        public string Softs { get; set; }

        public int Role_id { get; set; }
        public Role Role { get; set; }

        public int User_id { get; set; }
        public Users User { get; set; }


        public List<Orders_Designers> Orders_Designers { get; set; }

        public Designers()
        {
            Orders_Designers = new List<Orders_Designers>();
        }
    }
}
