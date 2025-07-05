using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.IAM.Domain.Model.Queries;
using KidycareBackend.IAM.Domain.Repositories;
using KidycareBackend.IAM.Domain.Services;

namespace KidycareBackend.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository): IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.username);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
}