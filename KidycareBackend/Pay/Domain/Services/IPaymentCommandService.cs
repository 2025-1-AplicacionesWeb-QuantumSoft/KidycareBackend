using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;

namespace KidycareBackend.Pay.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payment?> Handle(CreatePaymentCommand command);
}