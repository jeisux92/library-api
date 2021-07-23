using Amaris.Library.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amaris.Library.DataAccess
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
          : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
