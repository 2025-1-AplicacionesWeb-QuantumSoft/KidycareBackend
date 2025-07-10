using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Commands;

namespace KidycareBackend.Profiles.Domain.Services;

public interface IBabysitterCommandService
{
    Task<Babysitter?> Handle(CreateBabysitterCommand command);
    Task<Babysitter> Handle(UpdateBabysitterCommand command, int babysitterId);
}