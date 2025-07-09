using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.RegistrationServices.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<IEnumerable<Profile>> FindByProfileApiKeyAsync(string profileApiKey);
    Task<Profile?> FindByProfileApiKeyAndSourceIdAsync(string profileApiKey, string sourceId);
    Task<Profile?> GetProfileSourceById(int profileId);
    Task<Profile?> GetProfileSourceByUserId(int userId);
    Task<Profile?> UpdateProfileSource(Profile profile);
    Task DeleteProfileSource(int profileId);
}