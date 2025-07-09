using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.IAM.Interfaces.REST.Resources;

namespace KidycareBackend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, user.role, token);
    }
}