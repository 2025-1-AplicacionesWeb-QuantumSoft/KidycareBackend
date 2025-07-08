using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;

public class CardRepository(AppDbContext context) : BaseRepository<Card>(context), ICardRepository
{
    public async Task<Card?> GetCardById(long cardId)
    {
        return await Context.Set<Card>().FirstOrDefaultAsync(c => c.Id == cardId); 
    }
    
    public async Task<IEnumerable<Card>> GetCardByUserId(int userId)
    {
        return await Context.Set<Card>().Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<Card?> UpdateCard(Card card)
    {
        var trackedEntity = await Context.Set<Card>().FindAsync(card.Id);
        if (trackedEntity == null) return null;
        
        Context.Entry(trackedEntity).CurrentValues.SetValues(card);
        await Context.SaveChangesAsync();
        return trackedEntity;
    }

    public async Task DeleteCard(long cardId)
    {
        Context.Set<Card>().Remove(await GetCardById(cardId));
    }
}