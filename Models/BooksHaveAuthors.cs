using System;
namespace FinalProject.Models
{
    public class BooksHaveAuthors
    {
        public int Book_id { get; set; }
        public Books Book { get; set; }

        public int Author_id { get; set; }
        public Authors Authors { get; set; }
    }
}
