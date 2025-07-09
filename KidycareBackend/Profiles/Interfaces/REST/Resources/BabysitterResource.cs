namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record BabysitterResource(
    int id,
    int UserId,
    string name,
    string phone,
    string description,
    string languages,
    int rating,
    string location,
    string accountBank,
    string bankName,
    string typeAccountBank,
    string dni,
    string experienceLevel
    );