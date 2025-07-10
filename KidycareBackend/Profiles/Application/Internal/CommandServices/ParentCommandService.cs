using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Application.Internal.CommandServices;

public class ParentCommandService(IParentRepository parentRepository, IUnitOfWork unitOfWork) : IParentCommandService
{
    public async Task<Parent?> Handle(CreateParentCommand command)
    {
        var parent = new Parent(command);
        await parentRepository.AddAsync(parent);
        await unitOfWork.CompleteAsync();
        return parent;
    }

    public async Task<Parent?> Handle(UpdateParentCommand command)
    {
        var parent = await parentRepository.FindByIdAsync(command.Id);
        if (parent == null)
            throw new Exception("Parent not found");

        parent = new Parent(
            command.UserId,
            command.Address,
            command.Name,
            command.Phone,
            command.ChildrenCount,
            command.Preferences,
            command.City
        );
        try
        {
            parentRepository.Update(parent);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return parent;
        
    }
}