using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand toCommandFromResource( UpdateUserResource resource)
    {
        return new UpdateUserCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Password,
            resource.Phone,
            resource.role
        );
    }
}