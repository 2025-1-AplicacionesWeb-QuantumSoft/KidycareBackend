using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Queries;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;

namespace KidycareBackend.Pay.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository) : IPaymentQueryService
{
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query)
    {
        return await paymentRepository.ListAsync();
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentByParentIdQuery query)
    {
        return await paymentRepository.GetPaymentByParentId(query.ParentId);
    }

    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.GetPaymentById(query.Id);
    }
}