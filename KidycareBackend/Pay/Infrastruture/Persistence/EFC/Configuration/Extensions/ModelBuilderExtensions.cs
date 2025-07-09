using KidycareBackend.Pay.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCardConfiguration(this ModelBuilder builder)
    {
        //Cards context
        builder.Entity<Card>().HasKey(c => c.Id);
        builder.Entity<Card>().Property(c=>c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Card>().Property(c=>c.UserId).IsRequired();
        builder.Entity<Card>().Property(c=>c.CardNumber).IsRequired().HasMaxLength(100);
        builder.Entity<Card>().Property(c=>c.CardHolder).IsRequired().HasMaxLength(100);
        builder.Entity<Card>().Property(c => c.Cvv).IsRequired();
        builder.Entity<Card>().Property(c=>c.ExpirationDate).IsRequired();
        
    }
}