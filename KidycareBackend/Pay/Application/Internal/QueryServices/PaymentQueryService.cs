using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Pay.Domain.Model.Queries;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;

namespace KidycareBackend.Pay.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository) : IPaymentQueryService
{
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentByUserIdQuery query)
    {
        return await paymentRepository.FindByPaymentUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query)
    {
        return await paymentRepository.ListAsync();
    }
}