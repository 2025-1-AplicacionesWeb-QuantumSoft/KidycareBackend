using KidycareBackend.Pay.Domain.Model.Aggregates;

namespace KidycareBackend.Pay.Interfaces.ACL;

public interface ICardsContextFacade
{
    Task<int> CreateCard(
        int userId, string cardNumber, string cardName, string cardCvv, string cardExpirationDate);
    Task<int> DeleteCard(int cardId);
    Task<Card?> GetCardById(int cardId);
    Task<IEnumerable<Card>> GetCardByUserId(int cardId);
    Task<Card?> UpdateCard(Card card);
}