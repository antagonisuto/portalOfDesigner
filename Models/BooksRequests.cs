using System;
namespace FinalProject.Models
{
    public class BooksRequests
    {
        public int Book_id { get; set; }
        public Books Book { get; set; }

        public int User_id { get; set; }
        public Userss User { get; set; }

        public string RequestDate { get; set; }

    }
}
