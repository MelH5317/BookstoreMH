using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BookstoreMH.Data;
using BookstoreMH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreMH
{
    public class BookstoreService
    {
        readonly BookstoreContext _context;
        readonly ILogger _logger;
        public BookstoreService(BookstoreContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<BookstoreService>();
        }
        
        //list, create, update, and delete books
        public async Task<List<BookDetailViewModel>> GetBooks()
        {
            return await _context.Books
                .Select(x => new BookDetailViewModel
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Title = x.Title,
                    Price = double.Parse(x.Price),
                })
                .ToListAsync();
        }

        public async Task<Book> GetBook(int bookId)
        {
            return await _context.Books
                .Where(x => x.BookId == bookId)
                .SingleOrDefaultAsync();
        }


        public async Task<BookDetailViewModel> GetBookDetail(int bookId)
        {
            return await _context.Books
                .Where(x => x.BookId == bookId)
                .Select(x => new BookDetailViewModel
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Title = x.Title,
                    Price = double.Parse(x.Price),
                })
                .SingleOrDefaultAsync();
        }//End of public asyng task...




        public async Task<UpdateBookCommand> GetBookForUpdate(int bookId)
        {
            return await _context.Books
                .Where(x => x.BookId == bookId)
                .Select(x => new UpdateBookCommand
                {
                    Author = x.Author,
                    Title = x.Title,
                    Price = double.Parse(x.Price),
                })
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Create a new Book
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new book</returns>
        public async Task<int> CreateBook(CreateBookCommand cmd, ApplicationUser createdBy)
        {
            var book = cmd.ToBook(createdBy);
            _context.Add(book);
            await _context.SaveChangesAsync();
            return book.BookId;
        }

        /// <summary>
        /// Updateds an existing book
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new book</returns>
        public async Task UpdateBook(UpdateBookCommand cmd)
        {
            var book = await _context.Books.FindAsync(cmd.Id);
            if (book == null) { throw new Exception("Unable to find the book"); }

            cmd.UpdateBook(book);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Marks an existing recipe as deleted
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new book</returns>
        public async Task DeleteBook(int BookId)
        {
            var book = await _context.Books.FindAsync(BookId);
            if (book is null) { throw new Exception("Unable to find book"); }

            // TODO: Add DELETION of Book
            await _context.SaveChangesAsync();
        }
    }
}
