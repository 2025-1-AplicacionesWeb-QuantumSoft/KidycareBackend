using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record PaymentResource(
    int Id,
    decimal Amount,
    long CardId,
    string Status,
    DateTime? CreatedAtDate,
    int ReservationId,
    int ParentId
    );