using LibraryManagement.Database.Context;

namespace LibraryManagement.Database.Repositories
{
    public class BaseRepository
    {
        protected readonly LibraryDbContext _libraryDbContext;

        public BaseRepository(LibraryDbContext libraryDbContext)
        {
            this._libraryDbContext = libraryDbContext;
        }

        public void SaveChanges()
        {
            _libraryDbContext.SaveChanges();
        }
    }
}
