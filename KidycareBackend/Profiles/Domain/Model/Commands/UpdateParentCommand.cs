namespace KidycareBackend.Profiles.Domain.Model.Commands;

public record UpdateParentCommand(
    int Id,
    int UserId,
    string Name,
    string Phone,
    string Address,
    int ChildrenCount,
    string Preferences,
    string City
    );
    