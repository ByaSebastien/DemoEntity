using DemoEntity.DAL.Contexts;
using DemoEntity.DAL.Models;
using DemoEntity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private LibraryContext _context { get; set; }

        public DbController(LibraryContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BookDTO> books = _context.Books.Include(b => b.Author)
                .Where(b => b.Author.Name == "Sun tzu")
                .Select(b => BookDTO.fromEntity(b));

            return Ok(books);
        }

        [HttpGet("post")]
        public IActionResult Post()
        {
            Author author = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Robert"
            };

            author = _context.Authors.Add(author).Entity;

            Book book = new Book()
            {
                Isbn = "12345678911",
                Title = "Robert a la playa",
                Description = "taratata",
                Author = author,
            };

            _context.Books.Add(book);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
