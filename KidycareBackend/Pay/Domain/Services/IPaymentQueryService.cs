using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Queries;

namespace KidycareBackend.Pay.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query);
    Task<IEnumerable<Payment>> Handle(GetAllPaymentByParentIdQuery query);
    Task<Payment?> Handle(GetPaymentByIdQuery query);
}