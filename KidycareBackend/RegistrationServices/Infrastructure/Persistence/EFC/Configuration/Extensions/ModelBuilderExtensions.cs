using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.RegistrationServices.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyRegistrationServicesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().Property(p => p.SourceId).IsRequired().HasMaxLength(100);
        builder.Entity<Profile>().Property(p => p.ProfileApiKey).IsRequired().HasMaxLength(100);

        builder.Entity<Profile>().Property(p => p.UserId).IsRequired();
        builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Profile>().Property(p => p.Lastname).IsRequired().HasMaxLength(100);
        builder.Entity<Profile>().Property(p => p.Email).IsRequired().HasMaxLength(150);
        builder.Entity<Profile>().Property(p => p.Phone).HasMaxLength(20);
        builder.Entity<Profile>().Property(p => p.Location).HasMaxLength(100);
        builder.Entity<Profile>().Property(p => p.Experience).IsRequired();
        builder.Entity<Profile>().Property(p => p.Biography).HasMaxLength(1000);
        builder.Entity<Profile>().Property(p => p.About).HasMaxLength(1000);
        builder.Entity<Profile>().Property(p => p.Rating).IsRequired();
    }

}