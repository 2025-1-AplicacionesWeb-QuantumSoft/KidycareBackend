namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record CreateParentResource(
    int userId,
    string name,
    string phone,
    string address,
    int childrenCount,
    string preferences,
    string city);