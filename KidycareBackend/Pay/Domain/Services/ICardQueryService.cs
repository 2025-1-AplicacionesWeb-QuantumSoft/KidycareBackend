using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Queries;

namespace KidycareBackend.Pay.Domain.Services;

public interface ICardQueryService
{
    Task<IEnumerable<Card>> Handle(GetAllCardQuery query);
    Task<IEnumerable<Card?>> Handle(GetAllCardByBabysitterIdQuery query);
    Task<IEnumerable<Card>> Handle(GetAllCardByParentIdQuery query);
    
    
    Task<Card?> Handle(GetCardByIdQuery query);
}