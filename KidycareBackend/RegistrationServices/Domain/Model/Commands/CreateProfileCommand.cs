
namespace KidycareBackend.RegistrationServices.Domain.Model.Commands
{
    /// <summary>
    /// Command to create a profile.
    /// </summary>
    public record CreateProfileCommand(
        int UserId,
        string Name,
        string Lastname,
        string Email,
        string Phone,
        string Location,
        int Experience,
        string Biography,
        string About,
        double Rating,
        string ProfileApiKey,
        string SourceId
    );
}
