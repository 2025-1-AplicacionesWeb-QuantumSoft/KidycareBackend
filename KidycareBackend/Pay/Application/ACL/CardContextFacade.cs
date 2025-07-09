using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Queries;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;
using KidycareBackend.Pay.Interfaces.ACL;

namespace KidycareBackend.Pay.Application.ACL;

public class CardContextFacade(ICardQueryService cardQueryService): ICardsContextFacade 
{
    public async Task<Card?> GetCardByIdAsync(long cardId)
    {
        var query = new GetCardByIdQuery(cardId);
        return await cardQueryService.Handle(query);
    }

    public async Task<IEnumerable<Card?>> GetCardsByParentIdAsync(int parentId)
    {
        var query = new GetAllCardByParentIdQuery(parentId);
        return await cardQueryService.Handle(query);
    }

    public async Task<IEnumerable<Card?>> GetCardsByBabysitterIdAsync(int babysitterId)
    {
        var query = new GetAllCardByBabysitterIdQuery(babysitterId);
        return await cardQueryService.Handle(query);
    }

    public async Task<bool> ExistsCardWithIdAsync(long cardId)
    {
        var query = new GetCardByIdQuery(cardId);
        var card = await cardQueryService.Handle(query);
        return card != null; 
    }
}