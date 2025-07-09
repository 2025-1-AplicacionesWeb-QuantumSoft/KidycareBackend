using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CreatePaymentResource(
        decimal Amount,
        int CardId,
        PaymentStatus Status,
        DateTime CreateAt,
        int ReservationId,
        int UserId
    );