using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Database.Entities;

namespace LibraryManagement.Core.Mapping
{
    public static class BookMappingExtensions
    {
        public static BookResponseDto ToBookResponseDto(this Book book)
        {
            var result = new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.FullName
            };

            return result;
        }

        public static List<BookResponseDto> MapToBookResponseDtos(this List<Book> books)
        {
            return books.Select(b => b.ToBookResponseDto()).ToList();
        }

        public static Book ToBook(this BookRequestDto book)
        {
            return new Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId
            };
        }
    }
}
