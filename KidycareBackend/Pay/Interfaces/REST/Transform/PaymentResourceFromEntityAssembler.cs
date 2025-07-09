using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(entity.Id, entity.Amount, entity.Card, entity.Status, entity.CreatedAt,
            entity.ReservationId, entity.UserId);
    }
}