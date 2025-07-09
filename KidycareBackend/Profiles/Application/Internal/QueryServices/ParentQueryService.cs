using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;

namespace KidycareBackend.Profiles.Application.Internal.QueryServices;

public class ParentQueryService(IParentRepository parentRepository)
    : IParentQueryService
{
    public async Task<Parent?> Handle(GetParentByIdQuery query)
    {
        return await parentRepository.FindByIdAsync(query.ParentId);
    }

    public async Task<Parent?> Handle(GetParentByUserIdQuery query)
    {
        return await parentRepository.GetParentByUserId(query.UserId);
    }

    public async Task<IEnumerable<Parent>> Handle(GetAllParentsQuery query)
    {
        return await parentRepository.ListAsync();
    }
}
