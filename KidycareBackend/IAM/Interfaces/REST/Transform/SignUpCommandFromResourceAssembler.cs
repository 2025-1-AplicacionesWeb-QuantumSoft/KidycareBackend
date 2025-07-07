using KidycareBackend.IAM.Domain.Model.Commands;
using KidycareBackend.IAM.Interfaces.REST.Resources;

namespace KidycareBackend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password, resource.Role);
    }
}