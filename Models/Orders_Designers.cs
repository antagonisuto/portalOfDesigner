using System;
namespace FinalProject.Models
{
    public class Orders_Designers
    {
       

        public int Order_id { get; set; }
        public Orders Order { get; set; }

        public int Designer_id { get; set; }
        public Designers Designer { get; set; }

    }
}
