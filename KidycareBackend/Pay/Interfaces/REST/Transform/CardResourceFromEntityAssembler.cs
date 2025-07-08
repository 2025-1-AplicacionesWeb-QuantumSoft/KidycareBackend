using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class CardResourceFromEntityAssembler
{
    public static CardResource ToResourceFromEntity(Card entity)
    {
        return new CardResource(
            entity.Id,
            entity.UserId,
            entity.CardNumber.NumberCard,
            entity.CardHolder,
            entity.Cvv.Code,
            entity.ExpirationDate.Month,
            entity.ExpirationDate.Year
            );
    }
}