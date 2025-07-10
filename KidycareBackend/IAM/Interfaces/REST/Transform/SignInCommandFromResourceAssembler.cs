using KidycareBackend.IAM.Domain.Model.Commands;
using KidycareBackend.IAM.Interfaces.REST.Resources;

namespace KidycareBackend.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}