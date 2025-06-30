namespace KidycareBackend.Reservations.Interfaces.Resources;

public record UpdateReservationResource(
    int BabysitterId,
    int ParentId,
    DateTime StartTime,
    DateTime EndTime,
    string address,
    string frecuency,
    string ChildName,
    string ChildAge,
    string SpecialNeeds,
    string AdditionalInfo,
    string Status,
    int NotificationId,
    DateTime CreatedAt
    );