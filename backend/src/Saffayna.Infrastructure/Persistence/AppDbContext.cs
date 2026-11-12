using Microsoft.EntityFrameworkCore;
using Saffayna.Domain.Entities;

namespace Saffayna.Infrastructure.Persistence;

// The DbContext is our "door" to the database.
public class AppDbContext : DbContext
{
    // Receives settings (which database, which password) from outside.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Each DbSet becomes one table.
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    // Extra rules for the tables.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Money: up to 18 digits, 2 after the decimal point.
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount).HasPrecision(18, 2);

        // Category name is required and limited to 100 characters.
        modelBuilder.Entity<Category>()
            .Property(c => c.Name).IsRequired().HasMaxLength(100);

        // A category that still has expenses cannot be deleted (protects your history).
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category)             // each transaction has one category
            .WithMany()                          // a category has many transactions (we don't expose the list)
            .HasForeignKey(t => t.CategoryId)    // linked through CategoryId
            .OnDelete(DeleteBehavior.Restrict);  // refuse the delete instead of cascading
    }
}