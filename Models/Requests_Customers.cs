using System;
namespace FinalProject.Models
{
    public class Requests_Customers
    {
        public int Request_id { get; set; }
        public Requests Request { get; set; }

        public int Customers_id { get; set; }
        public Customers Customer { get; set; }

    }
}
