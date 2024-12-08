using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Domain.ValueObjects;
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
    public DbSet<ContactInformation> ContactInformation { get; set; }
    public DbSet<Newsletter> Newsletter { get; set; }
    public DbSet<Institute> Institute { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>().HasOne(img => img.Album).WithMany(album => album.Images)
            .HasForeignKey(img => img.AlbumId).OnDelete(DeleteBehavior.Cascade);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pioneers>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.CityOfBirth);
            entity.Property(p => p.ImagePath);
            entity.Property(p => p.ProjectsDescription);
        });
        modelBuilder.Entity<ContactUs>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FullName).IsRequired();
            entity.Property(c => c.Email);
            entity.Property(c => c.Subject);
            entity.Property(c => c.Body);
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

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Title);
            entity.Property(n => n.ImagePath);
            entity.Property(n => n.Summery);
            entity.Property(n => n.Body);
            entity.Property(n => n.Date);
        });
        
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Institute)
            .WithMany(i => i.Projects)
            .HasForeignKey(p => p.InstituteId);
        modelBuilder.Entity<Project>()
            .Property(p => p.Status)
            .HasDefaultValue(ProjectStatus.NeedsRevision);

        base.OnModelCreating(modelBuilder);
        
    }
}