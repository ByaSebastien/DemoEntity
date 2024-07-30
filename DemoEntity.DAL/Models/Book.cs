using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntity.DAL.Models
{
    public class Book
    {
        [Required]
        [Key]
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        [ForeignKey("Author_ID")]
        public Author Author { get; set; } = null!;
    }
}
