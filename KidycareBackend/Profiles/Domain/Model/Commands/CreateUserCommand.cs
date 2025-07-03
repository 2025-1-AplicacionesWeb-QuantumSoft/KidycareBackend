using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, string EmailAddress, 
string Password, string Phone, RoleType Role);