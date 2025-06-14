using KidycareBackend.Pay.Domain.Model.Entities;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Shared.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context): 
    BaseRepository<Payment>(context), IPaymentRepository
{
    public new async Task<IEnumerable<Payment>> FindByPaymentUserIdAsync(int userId)
    {
        return await Context.Set<Payment>()
            .Include(payment => payment.UserId )
            .Where(payment =>payment.UserId == userId )
            .ToListAsync();
    }
}