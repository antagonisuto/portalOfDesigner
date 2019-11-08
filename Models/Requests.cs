using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Requests
    {
        [Key]
        public int Request_id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public int User_id { get; set; }
        public Users User { get; set; }

        public int State_id { get; set; }
        public States State { get; set; }

        public List<Requests_Customers> Requests_Customers { get; set; }

        public Requests()
        {
            Requests_Customers = new List<Requests_Customers>();
        }
    }
}
