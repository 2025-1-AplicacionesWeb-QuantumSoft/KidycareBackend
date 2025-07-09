using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Model.Commands;

public record CreateReservationCommand(
    BabysitterId BabysitterId,
    ParentId ParentId,
    ReservationDate StartTime,
    ReservationDate EndTime,
    ReservationStatus Status,
    NotificationId NotificationId,
    DateTime CreatedAt
    );
    