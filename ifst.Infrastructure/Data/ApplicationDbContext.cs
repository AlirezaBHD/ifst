﻿using ifst.API.ifst.Domain.Entities;
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
    public DbSet<PublicImage> PublicImage { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<AparatVideo> AparatVideos { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<UpdateProject> UpdateProject { get; set; }
    public DbSet<Fund> Fund { get; set; }
    public DbSet<Student> Students { get; set; }

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
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Updates)
            .WithOne(u => u.Project)
            .HasForeignKey(u => u.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Fund)
            .WithMany(f => f.Projects)
            .HasForeignKey(p => p.FundId)
            .OnDelete(DeleteBehavior.SetNull);
        
        
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Institute)
            .WithMany(i => i.Students)
            .HasForeignKey(s => s.InstituteId);

        modelBuilder.Entity<PublicImage>(entity =>
        {
            entity.HasKey(pi => pi.Id);
            entity.Property(pi => pi.Path);
            entity.Property(pi => pi.Description);
        });
        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Title);
            entity.Property(n => n.ImagePath);
            entity.Property(n => n.Summery);
            entity.Property(n => n.Body);
            entity.Property(n => n.Date);
        });
        modelBuilder.Entity<AparatVideo>(entity =>
        {
            entity.HasKey(av => av.Id);
            entity.Property(av => av.Title);
            entity.Property(av => av.VideoScript);
        });

        modelBuilder.Entity<AboutUs>(entity =>
        {
            entity.HasKey(au => au.Id);
            entity.Property(au => au.Introduction);
            entity.Property(au => au.Statutes);
            entity.Property(au => au.ActivityLicense);
            entity.Property(au => au.FoundingBoard);
            entity.Property(au => au.BoardOfTrustees);
            entity.Property(au => au.BoardOfDirectors);
            entity.Property(au => au.CEO);
            entity.Property(au => au.CommitteesAndWorkingGroups);
            entity.Property(au => au.Archive);
            entity.Property(au => au.Reports);
        });

        modelBuilder.Entity<UpdateProject>(entity =>
        {
            entity.HasOne(up => up.Project).WithMany(p => p.Updates).HasForeignKey(up => up.ProjectId);
        });

        base.OnModelCreating(modelBuilder);
    }
}