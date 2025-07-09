using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.IAM.Interfaces.REST.Resources;

namespace KidycareBackend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}