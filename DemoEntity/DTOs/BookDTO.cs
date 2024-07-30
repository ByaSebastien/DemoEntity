using DemoEntity.DAL.Models;

namespace DemoEntity.DTOs
{
    public class BookDTO
    {
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string AuthorName { get; set; } = null!;

        public static BookDTO fromEntity(Book b)
        {
            return new BookDTO
            {
                Isbn = b.Isbn,
                Title = b.Title,
                AuthorName = b.Author.Name
            };
        }
    }
}
