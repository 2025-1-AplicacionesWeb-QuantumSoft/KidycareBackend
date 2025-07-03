using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Interfaces.REST.Resources;

public record UserResource(int userId,string FullName,string EmailAddress,string Password,string Phone,RoleType role);