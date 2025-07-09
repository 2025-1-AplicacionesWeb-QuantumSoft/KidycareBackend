using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public class CreateBabysitterCommandFromResourceAssembler
{
    public static CreateBabysitterCommand ToCommandFromResource(CreateBabysitterResource resource) =>
        new CreateBabysitterCommand(
            resource.UserId,
            resource.description,
            resource.name,
            resource.phone,
            resource.languages,
            resource.rating,
            resource.location,
            resource.accountBank,
            resource.bankName,
            resource.typeAccountBank,
            resource.dni,
            resource.experienceLevel
        );
}