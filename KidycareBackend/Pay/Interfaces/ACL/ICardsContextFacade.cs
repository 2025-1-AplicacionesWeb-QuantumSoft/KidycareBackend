using KidycareBackend.Pay.Domain.Model.Aggregates;

namespace KidycareBackend.Pay.Interfaces.ACL;

public interface ICardsContextFacade
{
    Task<Card?> GetCardByIdAsync(long cardId);
    Task<IEnumerable<Card?>> GetCardsByParentIdAsync(int parentId);
    Task<IEnumerable<Card?>> GetCardsByBabysitterIdAsync(int babysitterId);
    Task<bool> ExistsCardWithIdAsync(long cardId);
}