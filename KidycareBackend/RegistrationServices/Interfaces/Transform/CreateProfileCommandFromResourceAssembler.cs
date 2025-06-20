using KidycareBackend.RegistrationServices.Domain.Model.Commands;
using KidycareBackend.RegistrationServices.Interfaces.Resources;

namespace KidycareBackend.RegistrationServices.Interfaces.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource) =>
        new CreateProfileCommand(
            resource.UserId,
            resource.Name,
            resource.Lastname,
            resource.Email,
            resource.Phone,
            resource.Location,
            resource.Experience,
            resource.Biography,
            resource.About,
            resource.Rating,
            resource.ProfileApiKey,
            resource.SourceId
        );
}