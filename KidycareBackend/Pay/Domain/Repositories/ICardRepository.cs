using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Domain.Repositories;

public interface ICardRepository:IBaseRepository<Card>
{
    Task<Card?> GetCardById(int cardId);
    Task<IEnumerable<Card>> GetCardByUserId(int cardId);
    Task<Card?> UpdateCard(Card card);
    Task DeleteCard(int cardId);
}