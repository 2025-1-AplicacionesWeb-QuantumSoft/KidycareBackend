using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Queries;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;

namespace KidycareBackend.Pay.Application.Internal.QueryServices;

public class CardQueryService(ICardRepository cardRepository) : ICardQueryService
{
    public async Task<IEnumerable<Card>> Handle(GetAllCardByUserIdQuery query)
    {
        return await cardRepository.FindByCardByUserIdAsync(query.User_Id);
    }

    public async Task<IEnumerable<Card>> Handle(GetAllCardQuery query)
    {
        return await cardRepository.ListAsync();
    }
}