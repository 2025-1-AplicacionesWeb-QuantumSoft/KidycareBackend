namespace KidycareBackend.Profiles.Domain.Model.Commands;

public record UpdateBabysitterCommand(
    int Id,
    int UserId,
    string Description,
    string Name,
    string Phone,
    string Languages,
    int Rating,
    string Location,
    string AccountBank,
    string BankName,
    string TypeAccountBank,
    string Dni,
    string ExperienceLevel);
    