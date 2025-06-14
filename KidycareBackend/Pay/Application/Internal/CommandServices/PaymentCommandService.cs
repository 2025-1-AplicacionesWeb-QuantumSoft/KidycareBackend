using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork): IPaymentCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payment(command);
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }
}