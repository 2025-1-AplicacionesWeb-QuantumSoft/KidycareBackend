using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;

namespace KidycareBackend.Profiles.Application.Internal.QueryServices;

public class BabysitterQueryService(IBabysitterRepository babysitterRepository) 
    : IBabysitterQueryService
{
    public async Task<Babysitter?> Handle(GetBabysitterByIdQuery query)
    {
        return await babysitterRepository.FindByIdAsync(query.BabysitterId);
    }

    public async Task<Babysitter?> Handle(GetBabysitterByUserIdQuery query)
    {
        return await babysitterRepository.FindByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Babysitter>> Handle(GetAllBabysitterQuery query)
    {
        return await babysitterRepository.ListAsync();
    }
}