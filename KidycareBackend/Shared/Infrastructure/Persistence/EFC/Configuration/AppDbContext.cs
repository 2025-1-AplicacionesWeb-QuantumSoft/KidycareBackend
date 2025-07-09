using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Pay.Infrastruture.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using KidycareBackend.RegistrationServices.Infrastructure.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Reservations.Infrastructure.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;

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

        
        builder.ApplyProfilesConfiguration();
        builder.ApplyCardConfiguration();
        builder.ApplyReservationConfiguration();
        builder.ApplyRegistrationServicesConfiguration();
        builder.ApplyReviewsConfiguration();
        builder.ApplyIamConfiguration();
        
        
        
        
        
        builder.UseSnakeCaseNamingConvention();
        
    }
}