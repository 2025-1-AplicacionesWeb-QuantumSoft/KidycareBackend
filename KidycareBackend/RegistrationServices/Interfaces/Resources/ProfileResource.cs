namespace KidycareBackend.RegistrationServices.Interfaces.Resources;

public record ProfileResource(
    int Id,
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