namespace KidycareBackend.Profiles.Domain.Model.Commands;

public record CreateBabysitterCommand(
    int UserId,
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
    string experienceLevel);
    
    