namespace KidycareBackend.Profiles.Domain.Model.Commands;

public record UpdateParentCommand(
    string Address,
    string Name,
    string Phone,
    int ChildrenCount,
    string Preferences,
    string City
    );
    