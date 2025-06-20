using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class CardResourceFromEntityAssembler
{
    public static CardResource ToResourceFromEntity(Card entity)
    {
        return new CardResource(entity.Id,entity.UserId,entity.CardNumber,entity.CardHolder,entity.Cvv,entity.ExpirationDate);
    }
}