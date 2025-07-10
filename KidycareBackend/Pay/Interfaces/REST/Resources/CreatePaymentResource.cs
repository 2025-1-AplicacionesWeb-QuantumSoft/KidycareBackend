using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CreatePaymentResource(
        decimal Amount,
        long CardId,
        DateTime CreatedAtDate,
        int ReservationId,
        int ParentId
    );