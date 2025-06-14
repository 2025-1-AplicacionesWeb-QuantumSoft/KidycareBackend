using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Domain.Repositories;

public interface ICardRepository:IBaseRepository<Card>
{
    Task<IEnumerable<Card>> FindByCardByUserIdAsync(int userId);
}