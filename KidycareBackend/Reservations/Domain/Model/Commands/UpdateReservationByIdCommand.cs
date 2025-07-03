using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Model.Commands;

public record UpdateReservationByIdCommand(
    int Id,
    BabysitterId babysitterId,
    ParentId parentId,
    ReservationDate startTime,
    ReservationDate endTime,
    string address,
    string frequency,
    string childName,
    int childAge,
    string specialNeeds,
    string additionalInfo,
    ReservationStatus status,
    NotificationId notificationId,
    DateTime createdAt);
    