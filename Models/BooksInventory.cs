using System;
namespace FinalProject.Models
{
    public class BooksInventory
    {
        public int Book_id { get; set; }
        public Books Book { get; set; }

        public int User_id { get; set; }
        public Userss User { get; set; }

    }
}
