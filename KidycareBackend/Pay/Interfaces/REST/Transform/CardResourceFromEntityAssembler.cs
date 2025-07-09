using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class CardResourceFromEntityAssembler
{
    public static CardResource ToResourceFromEntity(Card? entity)
    {
        // Asegurarse de que solo uno de ParentId o BabysitterId sea no nulo
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Card entity cannot be null.");
        }
        return new CardResource(
            entity.Id,
            entity.ParentId,
            entity.BabysitterId,
            entity.CardNumber.NumberCard,
            entity.CardHolder,
            entity.Cvv.Code,
            entity.ExpirationDate.Month,
            entity.ExpirationDate.Year
            );
    }
}