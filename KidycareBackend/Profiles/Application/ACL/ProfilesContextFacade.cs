using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Profiles.Interfaces.ACL;

namespace KidycareBackend.Profiles.Application.ACL;

public class ProfilesContextFacade(
    IParentQueryService parentQueryService,
    IBabysitterQueryService babysitterQueryService)
    : IProfilesContextFacade
{
    public async Task<bool> ExistsParentWithIdAsync(int parentId)
    {
        var getParentById = new GetParentByIdQuery(parentId);
        var parent = await parentQueryService.Handle(getParentById);
        return parent != null;
    }

    public async Task<bool> ExistsBabysitterWithIdAsync(int babysitterId)
    {
        var getBabysitterById = new GetBabysitterByIdQuery(babysitterId);
        var babysitter = await babysitterQueryService.Handle(getBabysitterById);
        return babysitter != null;
    }
    
}