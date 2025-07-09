using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public class ParentResourceFromEntityAssembler
{
    public static ParentResource ToResourceFromEntity(Parent entity)
    {
        return new ParentResource(
            entity.Id,
            entity.userId,
            entity.name,
            entity.phone,
            entity.address,
            entity.childrenCount,
            entity.preferences,
            entity.city
        );
    }
}