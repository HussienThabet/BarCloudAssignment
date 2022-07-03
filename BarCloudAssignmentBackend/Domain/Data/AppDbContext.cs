using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    }
}
