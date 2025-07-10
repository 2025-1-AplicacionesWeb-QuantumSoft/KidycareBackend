using KidycareBackend.Reviews.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class MolderBuilderExtensions
{
    public static void ApplyReviewsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Review>().HasKey(p => p.reviewId);
        builder.Entity<Review>().Property(p => p.reviewId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p => p.reviewId).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.rating).IsRequired();
        builder.Entity<Review>().Property(p => p.comment).HasMaxLength(500);
        builder.Entity<Review>().Property(p => p.parentId).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.babysitterId).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.date).IsRequired();
    }
}