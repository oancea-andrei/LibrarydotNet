using LibraryManagement.Database.Context;
using LibraryManagement.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database.Repositories
{
    public class AuthorRepository : BaseRepository
    {
        public AuthorRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }

        public List<Author> GetAuthors()
        {
            var result = _libraryDbContext.Authors
                .Include(a => a.Books)
                .AsNoTracking()
                .ToList();

            return result;
        }

        public int CreateAuthor(Author author)
        {
            _libraryDbContext.Authors.Add(author);
            _libraryDbContext.SaveChanges();

            return author.Id;
        }
    }
}
