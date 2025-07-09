using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public static class UpdateParentCommandFromResourceAssembler
{
    public static UpdateParentCommand ToCommandFromResource(UpdateParentResource resource, int id)
    {
        return new UpdateParentCommand(
            resource.address,
            resource.name,
            resource.phone,
            resource.childrenCount,
            resource.preferences,
            resource.city
        );
    }
}