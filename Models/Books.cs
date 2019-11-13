using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Books
    {
        [Key]
        public int Book_id { get; set; }
        public string Book_title { get; set; }
        public int Book_page { get; set; }
        public DateTime Book_pub { get; set; }
        public string Book_shortDec { get; set; }
        public string Book_dec { get; set; }

        [ForeignKey("Publishers")]
        public int Pub_id { get; set; }
        public Publishers Publishers { get; set; }

        public ICollection<BooksRequests> BooksRequests { get; set; }
        public ICollection<BooksHaveAuthors> BooksHaveAuthors { get; set; }
        public ICollection<BooksInventory> BooksInventories { get; set; }
    }
}
