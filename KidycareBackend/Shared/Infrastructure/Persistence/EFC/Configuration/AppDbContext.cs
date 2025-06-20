using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using KidycareBackend.Reviews.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Review>().HasKey(p => p.reviewApiKey);
        builder.Entity<Review>().Property(p => p.reviewApiKey).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.reviewId).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.rating).IsRequired();
        builder.Entity<Review>().Property(p => p.comment).HasMaxLength(500);
        builder.Entity<Review>().Property(p => p.parentId).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.babysitterId).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.date).IsRequired();

        
        
        
        
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}