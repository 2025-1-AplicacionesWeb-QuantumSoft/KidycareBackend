using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.Entities;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork  unitOfWork): IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<User?> Handle(UpdateUserCommand command, int userId)
    {
        var user = await userRepository.GetUserByIdAsync(userId);
        try
        {
            if (user == null)
                throw new ArgumentException("User not found");

            user.Update(command);
            await userRepository.UpdateUserAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }
}