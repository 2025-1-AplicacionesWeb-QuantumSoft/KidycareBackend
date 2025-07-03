using KidycareBackend.Profiles.Domain.Model.Entities;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository  userRepository, IUnitOfWork  unitOfWork): IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.userId);
    }
}