using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Domain.Repositories;

public interface IPaymentRepository: IBaseRepository<Payment>
{
    Task<IEnumerable<Payment>> FindByPaymentUserIdAsync(int userId);
}