using LibraryManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Core.Dtos.Request;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Api.Controllers
{
    [Authorize(Roles = "Author")]
    [Route("api/Authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;
        public AuthorsController(AuthorService authorService, BookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpPost("/CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]


        public ActionResult<int> CreateAuthor([FromBody] AuthorRequestDto author)
        {
            int id = _authorService.CreateAuthor(author);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [HttpPost("CreateBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<int> CreateBook([FromBody] BookRequestDto book)
        {
            int id = _bookService.CreateBook(book);
            return StatusCode(StatusCodes.Status201Created, id);
        }
    }
}
