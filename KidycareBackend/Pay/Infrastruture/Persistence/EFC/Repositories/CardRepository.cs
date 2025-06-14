using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;

public class CardRepository(AppDbContext context) :
    BaseRepository<Card>(context), ICardRepository
{
    public new async Task<IEnumerable<Card>> FindByCardByUserIdAsync(int userId)
    {
        return await Context.Set<Card>()
            .Include(card => card.UserId)
            .Where(card => card.UserId == userId)
            .ToListAsync();
    }
}