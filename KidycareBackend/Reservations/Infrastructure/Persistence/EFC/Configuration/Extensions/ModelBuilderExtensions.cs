using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KidycareBackend.Reservations.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyReservationConfiguration(this ModelBuilder builder)
    {
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
            entity.Property(r => r.address).IsRequired();
            entity.Property(r => r.frecuency).IsRequired();
            entity.Property(r => r.childName).IsRequired();
            entity.Property(r => r.childAge).IsRequired();
            entity.Property(r => r.specialNeeds).IsRequired();
            entity.Property(r => r.additionalInfo).IsRequired();
            entity.Property(r => r.Status).HasConversion(reservationStatusConverter).IsRequired();
            entity.Property(r => r.CreatedAt).IsRequired();
        });
    }
}