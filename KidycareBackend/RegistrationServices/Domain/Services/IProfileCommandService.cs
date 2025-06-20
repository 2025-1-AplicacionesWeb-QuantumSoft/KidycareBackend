using KidycareBackend.RegistrationServices.Domain.Model.Commands;
using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;

namespace KidycareBackend.RegistrationServices.Domain.Services;

public interface IProfileCommandService
{
    /// <summary>
    /// Handle the command to create a profile.
    /// </summary>
    /// <param name="command">CreateProfileCommand</param>
    /// <returns>The created Profile or null if failed</returns>
    Task<Profile?> Handle(CreateProfileCommand command);
    /// <summary>
    /// Handle the command to update a profile.
    /// </summary>
    Task<Profile?> Handle(UpdateProfileCommand command, int profileId);
}