using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using KidycareBackend.RegistrationServices.Domain.Model.Queries;
using KidycareBackend.RegistrationServices.Domain.Repositories;
using KidycareBackend.RegistrationServices.Domain.Services;

namespace KidycareBackend.RegistrationServices.Application.Internal.QueryServices;

public class ProfileQueryService (IProfileRepository profileRepository)
    : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfileByProfileApiKeyQuery query)
    {
        return await profileRepository.FindByProfileApiKeyAsync(query.ProfileApiKey);
    }
    
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.GetProfileSourceById(query.Id);
    }
    
    public async Task<Profile?> Handle(GetProfileByProfileApiKeyAndSourceIdQuery query)
    {
        return await profileRepository.FindByProfileApiKeyAndSourceIdAsync(query.ProfileApiKey, query.SourceId);
    }

}