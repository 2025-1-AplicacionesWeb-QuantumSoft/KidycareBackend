using KidycareBackend.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        //IAM Context

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.role).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
    }
}


/*builder.Entity<User>().HasKey(u => u.Id);
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