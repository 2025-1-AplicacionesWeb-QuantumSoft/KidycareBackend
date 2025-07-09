using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class MolderBuilderExtensions
{
    
    public static void ApplyReviewsConfiguration(this ModelBuilder builder, string schema = "reviews")
    {
        var babysitterIdConverter = new ValueConverter<BabysitterId, int>(
            id => id.Value,
            value => new BabysitterId(value)
        );

        var parentIdConverter = new ValueConverter<ParentId, int>(
            id => id.Value,
            value => new ParentId(value)
        );
        
        builder.Entity<Review>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).ValueGeneratedOnAdd();
            
            entity.Property(r => r.ParentId).HasConversion(parentIdConverter).IsRequired();
            entity.Property(r => r.BabysitterId).HasConversion(babysitterIdConverter).IsRequired();
            
            // Apply value converters for the properties
            entity.Property(r => r.rating).IsRequired();
            entity.Property(r => r.comment).IsRequired();
            entity.Property(r => r.date).IsRequired();
            //entity.Property(r => r.reviewId).IsRequired();

        });
        
        
    }
    
   
}