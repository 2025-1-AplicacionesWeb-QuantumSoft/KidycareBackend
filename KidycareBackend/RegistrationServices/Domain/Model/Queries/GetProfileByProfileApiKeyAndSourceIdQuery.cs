namespace KidycareBackend.RegistrationServices.Domain.Model.Queries;

/// <summary>
/// Query to get a profile by its Profile API key and Source ID.
/// </summary>
/// <param name="ProfileApiKey"></param>
/// <param name="SourceId"></param>
public record GetProfileByProfileApiKeyAndSourceIdQuery(string ProfileApiKey, string SourceId);