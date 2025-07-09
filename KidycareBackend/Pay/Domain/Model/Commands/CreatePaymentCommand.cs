using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Domain.Model.Commands;

public record CreatePaymentCommand(
    decimal Amount,
    long CardId,
    DateTime CreatedAtDate,
    int ReservationId,
    int ParentId
    );