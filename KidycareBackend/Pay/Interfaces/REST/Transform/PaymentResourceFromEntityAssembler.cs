using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Id, 
            entity.Amount, 
            entity.CardId,
            entity.Status.ToString(), 
            entity.CreatedAtDate,
            entity.ReservationId, 
            entity.ParentId);
    }
}