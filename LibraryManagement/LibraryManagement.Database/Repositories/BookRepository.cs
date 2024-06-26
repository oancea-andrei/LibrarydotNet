using LibraryManagement.Database.Context;
using LibraryManagement.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database.Repositories
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        public List<Book> GetBooks()
        {
            var books = _libraryDbContext.Books
                                         .Include(b => b.Author)
                                         .ToList();
            return books;
        }

        public int CreateBook(Book book)
        {
            var author = _libraryDbContext.Authors.Find(book.AuthorId);

            if(author == null)
            {
                // Create middleware to handle exceptions
                throw new Exception("Author not found");
            }

            _libraryDbContext.Books.Add(book);
            _libraryDbContext.SaveChanges();

            return book.Id;
        }
    }
}
