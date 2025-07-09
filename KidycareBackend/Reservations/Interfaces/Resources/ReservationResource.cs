using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Interfaces.Resources;

public record ReservationResource(
    int Id,
    ParentId ParentId,
    BabysitterId BabysitterId,
    ReservationDate StartTime,
    ReservationDate EndTime,
    ReservationStatus Status,
    NotificationId NotificationId,
    DateTime CreatedAt
    );