using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public class BabysitterResourceFromEntityAssembler
{
    public static BabysitterResource ToResourceFromEntity(Babysitter entity)
    {
        return new BabysitterResource(
            entity.id,
            entity.UserId,
            entity.name,
            entity.phone,
            entity.description,
            entity.languages,
            entity.rating,
            entity.location,
            entity.accountBank,
            entity.bankName,
            entity.typeAccountBank,
            entity.dni,
            entity.ExperienceLevel
        );
    }
}