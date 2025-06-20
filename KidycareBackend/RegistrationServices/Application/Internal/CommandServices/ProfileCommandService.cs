using KidycareBackend.RegistrationServices.Domain.Model.Commands;
using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using KidycareBackend.RegistrationServices.Domain.Repositories;
using KidycareBackend.RegistrationServices.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.RegistrationServices.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = await profileRepository.FindByProfileApiKeyAndSourceIdAsync(command.ProfileApiKey, command.SourceId);
        if (profile is not null)
            throw new Exception("Profile already exists");

        profile = new Profile(command);

        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return profile;
    }
    
    public async Task<Profile?> Handle(UpdateProfileCommand command, int profileId)
    {
        var profile = await profileRepository.GetProfileSourceById(profileId);

        if (profile is null)
            throw new Exception("Profile not found");

        profile.Update(command);

        try
        {
            await profileRepository.UpdateProfileSource(profile);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return profile;
    }

}