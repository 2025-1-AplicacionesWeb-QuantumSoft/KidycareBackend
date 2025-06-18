namespace KidycareBackend.Reservations.Interfaces.Resources;

public record CreateReservationResource(
    int BabysitterId,
    int ParentId,
    DateTime StartTime,
    DateTime EndTime,
    string Status,
    int NotificationId,
    DateTime CreatedAt
);