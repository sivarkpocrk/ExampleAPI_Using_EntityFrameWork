using Microsoft.EntityFrameworkCore;
using CustomApi.Models;

namespace CustomApi.Data
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Author> Authors { get; set; } // Add this line for the Author table.
}
