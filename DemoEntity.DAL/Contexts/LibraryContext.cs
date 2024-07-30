using DemoEntity.DAL.Configs;
using DemoEntity.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntity.DAL.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();

        public LibraryContext(DbContextOptions options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
        }
    }
}
