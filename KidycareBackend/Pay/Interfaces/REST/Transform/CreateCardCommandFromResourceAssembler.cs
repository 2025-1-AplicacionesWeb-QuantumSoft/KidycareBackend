using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class CreateCardCommandFromResourceAssembler
{
    public static CreateCardCommand ToCommandFromResource(CreateCardResource resource)
    {
        
        return new CreateCardCommand(
            resource.ParentId == 0 ? (int?)null : resource.ParentId,
            resource.BabysitterId == 0 ? (int?)null : resource.BabysitterId,
            resource.NumberCard,
            resource.CardHolder,
            resource.Code,
            resource.Year,
            resource.Month

            );
        
    }
}