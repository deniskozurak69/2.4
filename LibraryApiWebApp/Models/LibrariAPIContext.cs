using Microsoft.EntityFrameworkCore;
namespace LibraryApiWebApp.Models
{
    public class LibrariAPIContext: DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public LibrariAPIContext(DbContextOptions<LibrariAPIContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
