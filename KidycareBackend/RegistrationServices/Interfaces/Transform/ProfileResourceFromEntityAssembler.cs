using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using KidycareBackend.RegistrationServices.Interfaces.Resources;

namespace KidycareBackend.RegistrationServices.Interfaces.Transform;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity) =>
        new ProfileResource(
            entity.Id,
            entity.UserId,
            entity.Name,
            entity.Lastname,
            entity.Email,
            entity.Phone,
            entity.Location,
            entity.Experience,
            entity.Biography,
            entity.About,
            entity.Rating,
            entity.ProfileApiKey,
            entity.SourceId
        );
}