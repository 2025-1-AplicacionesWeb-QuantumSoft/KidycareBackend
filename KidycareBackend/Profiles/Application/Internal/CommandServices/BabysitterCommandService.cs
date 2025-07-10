using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Application.Internal.CommandServices;

public class BabysitterCommandService(IBabysitterRepository babysitterRepository, IUnitOfWork unitOfWork) : IBabysitterCommandService
{
    public async Task<Babysitter?> Handle(CreateBabysitterCommand command)
    {
        var babysitter = new Babysitter(command);
        await babysitterRepository.AddAsync(babysitter);
        await unitOfWork.CompleteAsync();
        return babysitter;
    }

    public async Task<Babysitter?> Handle(UpdateBabysitterCommand command)
    {
        var babysitter = await babysitterRepository.FindByIdAsync(command.Id);
        if (babysitter == null)
            return null;

        babysitter = new Babysitter(
            command.UserId, 
            command.Name, 
            command.Phone, 
            command.Description, 
            command.Languages, 
            command.Rating,
            command.Location, 
            command.AccountBank, 
            command.BankName, 
            command.TypeAccountBank, 
            command.Dni, 
            command.ExperienceLevel
            );
        babysitterRepository.Update(babysitter);
        await unitOfWork.CompleteAsync();
        return babysitter;
    }
}