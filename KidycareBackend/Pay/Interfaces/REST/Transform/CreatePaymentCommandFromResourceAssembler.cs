using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Interfaces.REST.Resources;

namespace KidycareBackend.Pay.Interfaces.REST.Transform;

public static class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(
            resource.Amount, 
            resource.CardId, 
            resource.CreatedAtDate, 
            resource.ReservationId, 
            resource.ParentId);
    }
}