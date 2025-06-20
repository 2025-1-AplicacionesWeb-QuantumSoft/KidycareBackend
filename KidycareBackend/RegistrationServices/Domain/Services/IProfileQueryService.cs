using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using KidycareBackend.RegistrationServices.Domain.Model.Queries;

    
namespace KidycareBackend.RegistrationServices.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfileByProfileApiKeyQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
    Task<Profile?> Handle(GetProfileByProfileApiKeyAndSourceIdQuery query);
}