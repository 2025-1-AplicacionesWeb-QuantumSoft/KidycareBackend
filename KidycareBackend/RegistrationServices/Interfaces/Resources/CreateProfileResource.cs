namespace KidycareBackend.RegistrationServices.Interfaces.Resources;

public record CreateProfileResource(
    string ProfileApiKey,
    string SourceId,
    int UserId,
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