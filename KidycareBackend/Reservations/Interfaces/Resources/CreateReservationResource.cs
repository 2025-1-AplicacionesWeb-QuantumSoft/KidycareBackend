namespace KidycareBackend.Reservations.Interfaces.Resources;

public record CreateReservationResource(
    int babysitterId,
    int parentId,
    DateTime startTime,
    DateTime endTime,
    string address,
    string frequency,
    string childName,
    int childAge,
    string specialNeeds,
    string additionalInfo,
    string status,
    int notificationId,
    DateTime createdAt
);