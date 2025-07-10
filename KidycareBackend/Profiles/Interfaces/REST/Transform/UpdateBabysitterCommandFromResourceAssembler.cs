using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Interfaces.REST.Resources;

namespace KidycareBackend.Profiles.Interfaces.REST.Transform;

public static class UpdateBabysitterCommandFromResourceAssembler
{
    public static UpdateBabysitterCommand ToCommandFromResource( UpdateBabysitterResource resource,int id)
    {
        return new UpdateBabysitterCommand(
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
}