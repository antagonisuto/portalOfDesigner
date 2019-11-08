using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Customers
    {
        [Key]
        public int Customer_id { get; set; }
        public string Work_name { get; set; }
        public string Desc { get; set; }

        public int Role_id { get; set; }
        public Role Role { get; set; }

        public int User_id { get; set; }
        public Users User { get; set; }

        public List<Requests_Customers> Requests_Customers { get; set; }

        public Customers()
        {
            Requests_Customers = new List<Requests_Customers>();
        }
    }
}
