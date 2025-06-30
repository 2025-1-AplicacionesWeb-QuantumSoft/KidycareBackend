using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Model.Commands;

public record UpdateReservationByIdCommand(
    int Id,
    BabysitterId BabysitterId,
    ParentId ParentId,
    ReservationDate StartTime,
    ReservationDate EndTime,
    string address,
    string frecuency,
    string ChildName,
    string ChildAge,
    string SpecialNeeds,
    string AdditionalInfo,
    ReservationStatus Status,
    NotificationId NotificationId,
    DateTime CreatedAt);
    