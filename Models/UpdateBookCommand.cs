using System;
using BookstoreMH.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BookstoreMH.Models
{
    public class UpdateBookCommand : EditBookCommand
    {

        public int Id { get; set; }

        public void UpdateBook(Book book)
        {
            book.Author = Author;
            book.Title = Title;
            book.Price = Price.ToString();
        }
    }
}
