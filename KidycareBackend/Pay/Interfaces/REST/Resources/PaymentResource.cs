using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record PaymentResource(
    int Id,
    decimal Amount,
    Card Card,
    PaymentStatus Status,
    DateTime CreateAt,
    int ReservationId,
    int UserId
    );