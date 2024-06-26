using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Core.Mapping;
using LibraryManagement.Database.Repositories;

namespace LibraryManagement.Core.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookResponseDto> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            var bookResponseDtos = books.MapToBookResponseDtos();
            return bookResponseDtos;
        }

        public int CreateBook(BookRequestDto book)
        {
            int id = _bookRepository.CreateBook(book.ToBook());
            return id;
        }
    }
}
