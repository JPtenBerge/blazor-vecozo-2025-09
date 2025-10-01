using Demo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.DataAccess;

public class DemoContext : DbContext
{
    public DbSet<Burger> Burgers { get; set; } = null!;

    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burger>().HasKey(x => x.Id);

        modelBuilder.Entity<Burger>().Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Burger>().Property(x => x.Price)
            .IsRequired()
            .HasPrecision(8, 2);

        modelBuilder.Entity<Burger>().Property(x => x.Rating)
            .IsRequired()
            .HasPrecision(2, 1);

        modelBuilder.Entity<Burger>().Property(x => x.PhotoUrl)
            .IsRequired()
            .HasMaxLength(1000);
    }
}
