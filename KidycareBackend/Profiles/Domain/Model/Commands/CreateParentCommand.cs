namespace KidycareBackend.Profiles.Domain.Model.Commands;

public record CreateParentCommand(
    int userId,
    string name,
    string phone,
    string address,
    int childrenCount,
    string preferences,
    string city
    );
    
    