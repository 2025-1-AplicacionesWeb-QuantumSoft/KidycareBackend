using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand toCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Password,
            resource.Phone,
            resource.Role
        );
    }
}