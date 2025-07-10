using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Pay.Interfaces.ACL;

namespace KidycareBackend.Pay.Application.ACL;

public class PaymentContextFacade
    (IPaymentCommandService paymentCommandService)
    : IPaymentContextFacade
{
    public async Task<int> CreatePayment(decimal amount, long cardId, DateTime createdAtDate, int reservationId, int parentId)
    {
        var payment = await paymentCommandService.Handle(new CreatePaymentCommand(amount, cardId, createdAtDate, reservationId, parentId));
        return payment.Id;
    }
}