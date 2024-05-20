using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Genre
        mb.Entity<Genre>().HasKey(g => g.GenreId); // Opcional, o EF Core obtem automaticamente O ID

        mb.Entity<Genre>().
            Property(g => g.Name).
                HasMaxLength(100).
                    IsRequired();

        // Book
        mb.Entity<Book>().HasKey(b => b.Id);

        mb.Entity<Book>().
            Property(b => b.Title).
                HasMaxLength(100).
                IsRequired();

        mb.Entity<Book>().
           Property(b => b.Description).
               HasMaxLength(255).
               IsRequired();

        mb.Entity<Book>().
            Property(b => b.Author).
               HasMaxLength(100).
               IsRequired();

        mb.Entity<Book>().
            Property(b => b.Price).
               HasPrecision(10, 2);

        mb.Entity<Book>().
            Property(b => b.Stock).
               HasMaxLength(9999);

        mb.Entity<Genre>()
            .HasMany(b => b.Books)
                .WithOne(g => g.Genre)
                .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = 1,
                    Name = "Fantasia"
                },
                new Genre
                {
                    GenreId = 2,
                    Name = "Romance"
                }
            );
    }
}

