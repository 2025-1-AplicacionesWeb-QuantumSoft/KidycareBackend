using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Pay.Domain.Model.Queries;

namespace KidycareBackend.Pay.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentByUserIdQuery query);
    Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query);
}