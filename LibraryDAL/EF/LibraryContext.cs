using System.Data.Entity;
using LibraryDAL.Entities;
using LibraryDAL.Migrations;

namespace LibraryDAL.EF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {
        }

        static LibraryContext()
        {
            Database.SetInitializer<LibraryContext>(new ContextInitializer());
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
