namespace KidycareBackend.RegistrationServices.Domain.Model.Commands;

/// <summary>
/// Command to update an existing profile.
/// </summary>
public record UpdateProfileCommand(
    string Name,
    string Lastname,
    string Email,
    string Phone,
    string Location,
    int Experience,
    string Biography,
    string About,
    double Rating
);