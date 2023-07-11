using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreMH.Data;

namespace BookstoreMH.Models
{
    public class BookDetailViewModel
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
