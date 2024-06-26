using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Database.Entities;

namespace LibraryManagement.Core.Mapping
{
    public static class AuthorMappingExtensions
    {
        public static AuthorResponseDto ToAuthorResponseDto(this Author author)
        {
            var result = new AuthorResponseDto();

            result.Id = author.Id;
            result.FullName = author.FullName;

            List<BookResponseDto> booksDto = new List<BookResponseDto>();

            foreach (var book in author.Books)
            {
                booksDto.Add(book.ToBookResponseDto());
            }

            result.Books = booksDto;

            return result;
        }

        public static Author ToAuthor(this AuthorRequestDto author)
        {
            return new Author
            {
                FullName = author.FullName
            };
        }
    }
}
