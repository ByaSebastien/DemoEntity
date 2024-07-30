using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntity.DAL.Models
{
    public class Author
    {
        [Key]
        public Guid Id{ get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public IEnumerable<Book> Books { get; set; } = new List<Book>();    
    }
}
