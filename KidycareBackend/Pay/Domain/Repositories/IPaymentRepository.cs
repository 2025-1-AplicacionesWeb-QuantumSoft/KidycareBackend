using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Domain.Repositories;

public interface IPaymentRepository: IBaseRepository<Payment>
{
    //Task<IEnumerable<Payment>> ListAsync();
    Task<Payment?> GetPaymentById(int paymentId);
    Task<IEnumerable<Payment>> GetPaymentByParentId(int parentId);
    
}