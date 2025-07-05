
using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProfilesConfiguration(this ModelBuilder builder)
    {
        /*// Users Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().OwnsOne(u => u.Name,
        n =>
        {
            n.WithOwner().HasForeignKey("Id");
            n.Property(u => u.FirstName).HasColumnName("FirstName");
            n.Property(u => u.LastName).HasColumnName("LastName");
        });
        builder.Entity<User>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });
        builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<User>().Property(u=>u.Role).IsRequired().HasMaxLength(100);*/
        var userIdConverter = new ValueConverter<UserId, int>(
            id => id.Value,
            value => new UserId(value)
        );
        
        builder.Entity<Babysitter>().HasKey(b => b.id);
        builder.Entity<Babysitter>().Property(b => b.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Babysitter>().Property(b => b.name).IsRequired().HasMaxLength(100);
        builder.Entity<Babysitter>().Property(b => b.phone).IsRequired().HasMaxLength(9);
        builder.Entity<Babysitter>().Property(b => b.accountBank).IsRequired();
        builder.Entity<Babysitter>().Property(b => b.bankName).IsRequired().HasMaxLength(100);
        builder.Entity<Babysitter>().Property(b => b.typeAccountBank).IsRequired().HasMaxLength(100);
        builder.Entity<Babysitter>().Property(b => b.dni).IsRequired().HasMaxLength(9);
        builder.Entity<Babysitter>().Property(b => b.UserId).HasConversion(userIdConverter).IsRequired();
        builder.Entity<Babysitter>().Property(b => b.description).IsRequired().HasMaxLength(500);
        builder.Entity<Babysitter>().Property(b => b.languages).IsRequired().HasMaxLength(200);
        builder.Entity<Babysitter>().Property(b => b.rating).IsRequired().HasDefaultValue(0);
        builder.Entity<Babysitter>().Property(b => b.location).IsRequired().HasMaxLength(200);
        builder.Entity<Babysitter>().Property(b => b.ExperienceLevel).IsRequired().HasMaxLength(50);
        builder.Entity<Babysitter>().Property(b => b.IsAvailable).IsRequired().HasDefaultValue(true);
        
        
        
        builder.Entity<Parent>().HasKey(b => b.Id);
        builder.Entity<Parent>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Parent>().Property(b => b.name).IsRequired().HasMaxLength(100);
        builder.Entity<Parent>().Property(b => b.phone).IsRequired().HasMaxLength(9);
        builder.Entity<Parent>().Property(b => b.userId).HasConversion(userIdConverter).IsRequired();
        builder.Entity<Parent>().Property(b => b.address).IsRequired().HasMaxLength(200);
        builder.Entity<Parent>().Property(b => b.childrenCount).IsRequired();
        builder.Entity<Parent>().Property(b => b.preferences).IsRequired().HasMaxLength(500);
        builder.Entity<Parent>().Property(b => b.city).IsRequired().HasMaxLength(100);
    }
}