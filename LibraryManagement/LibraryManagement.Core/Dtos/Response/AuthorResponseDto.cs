namespace LibraryManagement.Core.Dtos.Response
{
    public class AuthorResponseDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<BookResponseDto> Books { get; set; }
    }
}
