using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;

namespace KidycareBackend.Profiles.Domain.Services;

public interface IBabysitterQueryService
{
    Task<Babysitter?> Handle(GetBabysitterByIdQuery query);

    Task<Babysitter?> Handle(GetBabysitterByUserIdQuery query);
    
    Task<IEnumerable<Babysitter>> Handle(GetAllBabysitterQuery query);
}