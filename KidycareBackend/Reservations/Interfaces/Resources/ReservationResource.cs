using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Interfaces.Resources;

public record ReservationResource(
    int Id,
    ParentId ParentId,
    BabysitterId BabysitterId,
    ReservationDate StartTime,
    ReservationDate EndTime,
    string Address,
    string Frequency,
    string ChildName,
    int ChildAge,
    string SpecialNeeds,
    string AdditionalInfo,
    ReservationStatus Status,
    NotificationId NotificationId,
    DateTime CreatedAt
    );