using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Authors
    {
        [Key]
        public int Author_id { get; set; }
        public string Author_name { get; set; }

        public ICollection<BooksHaveAuthors> BooksHaveAuthors { get; set; }
    }
}
