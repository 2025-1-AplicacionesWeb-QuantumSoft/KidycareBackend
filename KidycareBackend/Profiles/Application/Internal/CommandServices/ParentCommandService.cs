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

    public async Task<Parent> Handle(UpdateParentCommand command, int parentId)
    {
        var parentExisting = await parentRepository.GetParentById(parentId);
        if (parentExisting == null)
            throw new Exception("Card not found");
        
        try
        {
            if (!string.IsNullOrEmpty(command.Address))
                parentExisting.address = command.Address;

            if (!string.IsNullOrEmpty(command.Name))
                parentExisting.name = command.Name;

            if (!string.IsNullOrEmpty(command.Phone))
                parentExisting.phone = command.Phone;

            if (command.ChildrenCount != 0)
                parentExisting.childrenCount = command.ChildrenCount;

            if (!string.IsNullOrEmpty(command.Preferences))
                parentExisting.preferences = command.Preferences;

            if (!string.IsNullOrEmpty(command.City))
                parentExisting.city = command.City;
            
            await parentRepository.UpdateParent(parentExisting);
            await unitOfWork.CompleteAsync();
            return parentExisting;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}