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

    public async Task<Babysitter> Handle(UpdateBabysitterCommand command, int babysitterId)
    {
        var babysitterExisting = await babysitterRepository.GetBabysitterId(babysitterId);
        if (babysitterExisting == null)
            throw new Exception("Card not found");
        
        try
        {
            if (!string.IsNullOrEmpty(command.Description))
                babysitterExisting.description = command.Description;

            if (!string.IsNullOrEmpty(command.Name))
                babysitterExisting.name = command.Name;

            if (!string.IsNullOrEmpty(command.Phone))
                babysitterExisting.phone = command.Phone;

            if (!string.IsNullOrEmpty(command.Languages))
                babysitterExisting.languages = command.Languages;
            
            if (command.Rating != 0)
             babysitterExisting.rating = command.Rating;

            if (!string.IsNullOrEmpty(command.Location))
                babysitterExisting.location = command.Location;

            if (!string.IsNullOrEmpty(command.AccountBank))
                babysitterExisting.accountBank = command.AccountBank;

            if (!string.IsNullOrEmpty(command.BankName))
                babysitterExisting.bankName = command.BankName;

            if (!string.IsNullOrEmpty(command.TypeAccountBank))
                babysitterExisting.typeAccountBank = command.TypeAccountBank;

            if (!string.IsNullOrEmpty(command.Dni))
                babysitterExisting.dni = command.Dni;
            
            await babysitterRepository.UpdateBabysitter(babysitterExisting);
            await unitOfWork.CompleteAsync();
            return babysitterExisting;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

}