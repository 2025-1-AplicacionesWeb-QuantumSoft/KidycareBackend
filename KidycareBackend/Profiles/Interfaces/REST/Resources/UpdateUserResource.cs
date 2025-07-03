using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record UpdateUserResource(
    string LastName,
    string FirstName,
    string Email,
    string Password,
    string Phone,
    RoleType role
    );