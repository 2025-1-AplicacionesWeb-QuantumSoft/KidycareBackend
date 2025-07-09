using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Shared.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context): 
    BaseRepository<Payment>(context), IPaymentRepository
{
    public async Task<Payment?> GetPaymentById(int paymentId)
    {
        return await Context.Set<Payment>().FirstOrDefaultAsync(p => p.Id == paymentId);
    }

    public async Task<IEnumerable<Payment>> GetPaymentByParentId(int parentId)
    {
        return await Context.Set<Payment>().Where(p => p.ParentId == parentId).ToListAsync();
    }
}