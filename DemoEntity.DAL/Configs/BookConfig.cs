using DemoEntity.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntity.DAL.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Isbn);
            builder.HasIndex(b => b.Title).IsUnique();
            builder.ToTable(t => t.HasCheckConstraint("CK_BOOK_ISBN", "LEN(ISBN) = 11 OR LEN(ISBN) = 13"));
            builder.HasOne(b => b.Author).WithMany(a => a.Books).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
