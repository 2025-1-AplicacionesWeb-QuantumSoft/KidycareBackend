namespace KidycareBackend.Reservations.Interfaces.Resources;

public record CreateReservationResource(
    int BabysitterId,
    int ParentId,
    DateTime StartTime,
    DateTime EndTime,
    string address,
    string frequency,
    string childName,
    int childAge,
    string specialNeeds,
    string additionalInfo,
    string Status,
    int NotificationId,
    DateTime createdAt
);