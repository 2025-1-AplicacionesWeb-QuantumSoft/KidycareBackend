using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Model.Commands;

public record CreateReservationCommand(
    BabysitterId BabysitterId,
    ParentId ParentId,
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
    