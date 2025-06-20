namespace KidycareBackend.RegistrationServices.Domain.Model.Queries;

/// <summary>
/// Query to get all profiles by Profile API key.
/// </summary>
/// <param name="ProfileApiKey"></param>
public record GetAllProfileByProfileApiKeyQuery(string ProfileApiKey);