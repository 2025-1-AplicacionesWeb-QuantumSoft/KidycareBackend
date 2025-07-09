using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository paymentRepository,ICardRepository cardRepository, IUnitOfWork unitOfWork): IPaymentCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var card = await cardRepository.GetCardById(command.CardId);
        if (card == null)
        {
            throw new ArgumentException("La tarjeta seleccionada no existe.");
        }

        var payment = new Payment(command, card);
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }
}