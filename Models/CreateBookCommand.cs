using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreMH.Data;

namespace BookstoreMH.Models
{
    public class CreateBookCommand : EditBookCommand
    {
        public Book ToBook(ApplicationUser createdBy)
        {
            return new Book
            {
                Author = Author,
                Title = Title,
                Price = Price.ToString(),
            };
        }
    }
}
