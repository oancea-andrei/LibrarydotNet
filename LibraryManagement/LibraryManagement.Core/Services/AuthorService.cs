using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Core.Mapping;
using LibraryManagement.Database.Entities;
using LibraryManagement.Database.Repositories;

namespace LibraryManagement.Core.Services
{
    public class AuthorService 
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<AuthorResponseDto> GetAuthors()
        {
            List<Author> authors = _authorRepository.GetAuthors();

            List<AuthorResponseDto> authorResponseDtos = new List<AuthorResponseDto>();

            foreach (Author author in authors)
            {
                authorResponseDtos.Add(author.ToAuthorResponseDto());
            }

            return authorResponseDtos;
        }

        public int CreateAuthor(AuthorRequestDto author)
        {
            int id = _authorRepository.CreateAuthor(author.ToAuthor());
            return id;
        }
    }
}
