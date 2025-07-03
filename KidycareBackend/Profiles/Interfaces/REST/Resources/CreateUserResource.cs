using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record CreateUserResource(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Phone,
    RoleType Role
    );