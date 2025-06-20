using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Pay.Infrastruture.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;

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

        var reservationIdConverter = new ValueConverter<ReservationId, int>(
            id => id.Value,
            value => new ReservationId(value)
        );

        var babysitterIdConverter = new ValueConverter<BabysitterId, int>(
            id => id.Value,
            value => new BabysitterId(value)
        );

        var parentIdConverter = new ValueConverter<ParentId, int>(
            id => id.Value,
            value => new ParentId(value)
        );

        var notificationIdConverter = new ValueConverter<NotificationId, int>(
            id => id.Value,
            value => new NotificationId(value)
        );

        var reservationDateConverter = new ValueConverter<ReservationDate, DateTime>(
            date => date.Value,
            value => new ReservationDate(value)
        );

        var reservationStatusConverter = new ValueConverter<ReservationStatus, string>(
            status => status.Value,
            value => ReservationStatus.FromString(value)
        );

        builder.Entity<Reservation>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).ValueGeneratedOnAdd();

            entity.Property(r => r.BabysitterId).HasConversion(babysitterIdConverter).IsRequired();
            entity.Property(r => r.ParentId).HasConversion(parentIdConverter).IsRequired();
            entity.Property(r => r.NotificationId).HasConversion(notificationIdConverter).IsRequired();

            entity.Property(r => r.StartTime).HasConversion(reservationDateConverter).IsRequired();
            entity.Property(r => r.EndTime).HasConversion(reservationDateConverter).IsRequired();

            entity.Property(r => r.Status).HasConversion(reservationStatusConverter).IsRequired();
            entity.Property(r => r.CreatedAt).IsRequired();
        });
        
        builder.ApplyCardConfiguration();
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
        
        builder.UseSnakeCaseNamingConvention();
        
    }
}