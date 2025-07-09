using KidycareBackend.Profiles.Domain.Model.Entities;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id,entity.FullName,entity.EmailAddress,entity.Password,entity.Phone,entity.Role);
    }
}