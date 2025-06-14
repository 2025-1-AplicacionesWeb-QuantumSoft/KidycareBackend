using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class CreateCardCommandFromResourceAssembler
{
    public static CreateCardCommand ToCommandFromResource(CreateCardResource resource)
    {
        return new CreateCardCommand(resource.UserId, resource.CardNumber, resource.CardHolder, 
            resource.Cvv, resource.ExpirationDate);
        
    }
}