using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.ValueObjects;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCardConfiguration(this ModelBuilder builder)
    {
        
        //Cards context
        builder.Entity<Card>().HasKey(c => c.Id);
        builder.Entity<Card>().Property(c=>c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Card>().Property(c=>c.UserId).IsRequired();
        builder.Entity<Card>().OwnsOne(c => c.CardNumber, n =>
        {
            n.WithOwner().HasForeignKey("Id");
            n.Property(u => u.NumberCard).HasColumnName("CardNumber");
        });
        builder.Entity<Card>().Property(c=>c.CardHolder).IsRequired().HasMaxLength(100);
        builder.Entity<Card>().OwnsOne(c => c.Cvv, v =>
        {
            v.WithOwner().HasForeignKey("Id");
            v.Property(w => w.Code).HasColumnName("Cvv");
        });
        builder.Entity<Card>().OwnsOne(c=>c.ExpirationDate, e =>
        {
            e.WithOwner().HasForeignKey("Id");
            e.Property(a => a.Month).HasColumnName("ExpirationMonth");
            e.Property(a => a.Year).HasColumnName("ExpirationYear");
        });
        
    
        
        //Payment Context
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p=>p.Amount).IsRequired();
        builder.Entity<Payment>().Property(p=>p.CardId).IsRequired();
        builder.Entity<Payment>().Property(p=>p.Status).IsRequired();
        builder.Entity<Payment>().Property(p=>p.CreatedAtDate).IsRequired();
        builder.Entity<Payment>().Property(p=>p.ReservationId).IsRequired();
        builder.Entity<Payment>().Property(p => p.ParentId).IsRequired();
        
    }
}