using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.Entities;

namespace KidycareBackend.Profiles.Domain.Services;

public interface IUserCommandService
{
    public Task<User?> Handle(CreateUserCommand command);
    public Task<User?> Handle(UpdateUserCommand command, int userId);
}