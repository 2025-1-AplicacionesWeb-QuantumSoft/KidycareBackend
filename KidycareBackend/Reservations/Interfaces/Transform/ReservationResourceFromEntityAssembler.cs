using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Interfaces.Resources;

namespace KidycareBackend.Reservations.Interfaces.Transform;

public class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(Reservation entity) =>
        new ReservationResource(
            entity.Id,
            entity.ParentId,
            entity.BabysitterId,
            entity.StartTime,
            entity.EndTime,
            entity.Status,
            entity.NotificationId,
            entity.CreatedAt);
}