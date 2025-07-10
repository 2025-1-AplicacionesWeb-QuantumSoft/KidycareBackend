using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Commands;

namespace KidycareBackend.Profiles.Domain.Services;

public interface IParentCommandService
{

    Task<Parent?> Handle(CreateParentCommand command);
    
    Task<Parent> Handle(UpdateParentCommand command, int parentId);
}