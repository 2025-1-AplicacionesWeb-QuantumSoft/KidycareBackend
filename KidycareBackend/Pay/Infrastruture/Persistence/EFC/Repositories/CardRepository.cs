using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;

public class CardRepository(AppDbContext context) : BaseRepository<Card>(context), ICardRepository
{
    public async Task<Card?> GetCardById(int cardId)
    {
        return await Context.Set<Card>().FirstOrDefaultAsync(c => c.Id == cardId); 
    }

    public async Task<IEnumerable<Card>> GetCardByUserId(int userId)
    {
        return await Context.Set<Card>().Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<Card?> UpdateCard(Card card)
    {
        Context.Set<Card>().Update(card);
        await Context.SaveChangesAsync();
        return card;
    }

    public async Task DeleteCard(int cardId)
    {
        Context.Set<Card>().Remove(await GetCardById(cardId));
    }
}