using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public class CreateParentCommandFromResourceAssembler
{
    public static CreateParentCommand ToCommandFromResource(CreateParentResource resource) =>
        new CreateParentCommand(
            resource.userId,
            resource.name,
            resource.phone,
            resource.address,
            resource.childrenCount,
            resource.preferences,
            resource.city
        );
}