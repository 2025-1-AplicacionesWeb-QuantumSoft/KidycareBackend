using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Domain.Repositories;

public interface ICardRepository:IBaseRepository<Card>
{
    Task<Card?> GetCardById(long cardId);
    Task<IEnumerable<Card?>> GetCardByParentId(int parentId);
    Task<IEnumerable<Card?>> GetCardByBabysitterId(int babysitterId);
    Task<Card?> UpdateCard(Card card);
    Task DeleteCard(long cardId);
    
    Task<IEnumerable<Card>> ListAsync();
}