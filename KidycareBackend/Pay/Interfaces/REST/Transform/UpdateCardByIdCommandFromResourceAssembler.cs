using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class UpdateCardByIdCommandFromResourceAssembler
{
    public static UpdateCardByIdCommand ToCommandFromResource(UpdateCardResource resource, long id)
    {
        return new UpdateCardByIdCommand(
            resource.NumberCard,
            resource.CardHolder,
            resource.Code,
            resource.Month,
            resource.Year
        );
    }
}

