namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record UpdateBabysitterResource(
    string description,
    string name,
    string phone,
    string languages,
    int rating,
    string location,
    string accountBank,
    string bankName,
    string typeAccountBank,
    string dni,
    string experienceLevel
    
    );