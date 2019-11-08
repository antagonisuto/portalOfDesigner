using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Orders
    {
        [Key]
        public int Order_id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public int User_id { get; set; }
        public Users User { get; set; }

        public int State_id { get; set; }
        public States State { get; set; }

        public List<Orders_Designers> Orders_Designers { get; set; }

        public Orders()
        {
            Orders_Designers = new List<Orders_Designers>();
        }
    }
}
