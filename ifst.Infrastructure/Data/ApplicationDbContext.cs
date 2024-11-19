using ifst.API.ifst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ifst.API.ifst.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Image> Images { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Pioneers> Pioneers { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>().HasOne(img => img.Album).WithMany(album => album.Images)
            .HasForeignKey(img => img.AlbumId).OnDelete(DeleteBehavior.Cascade);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pioneers>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.CityOfBirth).HasMaxLength(100);
            entity.Property(p => p.ImagePath).HasMaxLength(250);
            entity.Property(p => p.ProjectsDescription).HasMaxLength(1000);
        });
        modelBuilder.Entity<ContactUs>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Email).HasMaxLength(100);
            entity.Property(c => c.Subject).HasMaxLength(100);
            entity.Property(c => c.Body).HasMaxLength(1000);
        });
        
        modelBuilder.Entity<ContactInformation>(entity =>
        {
            entity.HasKey(ci => ci.Id);
            entity.Property(ci => ci.Phone);
            entity.Property(ci => ci.Number);
            entity.Property(ci => ci.Email);
            entity.Property(ci => ci.Address);
            entity.Property(ci => ci.PostCode);
            entity.Property(ci => ci.Location);
        });
        modelBuilder.Entity<Newsletter>(entity =>
        {
            entity.HasKey(ci => ci.Id);
            entity.Property(ci => ci.Title);
            entity.Property(ci => ci.ImagePath);
            entity.Property(ci => ci.FilePath);
        });
    }
}