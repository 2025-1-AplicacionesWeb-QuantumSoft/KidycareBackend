using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Domain.Model.Commands;

public record CreatePaymentCommand(
    decimal Amount,
    int CardId,
    PaymentStatus Status,
    DateTime CreatedAt,
    int ReservationId,
    int UserId
    );