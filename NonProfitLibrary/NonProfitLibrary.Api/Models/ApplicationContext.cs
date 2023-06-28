using Microsoft.EntityFrameworkCore;

namespace NonProfitLibrary.Api.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Reader> Reader { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }
    }

    
}
