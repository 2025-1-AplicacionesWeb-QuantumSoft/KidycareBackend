namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record UpdateParentResource(
    
    string address,
    string name,
    string phone,
    int childrenCount,
    string preferences,
    string city
    
    );