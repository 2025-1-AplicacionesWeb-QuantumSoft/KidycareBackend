namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record ParentResource(
    int id,
    int userId,
    string name,
    string phone,
    string address,
    int childrenCount,
    string preferences,
    string city);