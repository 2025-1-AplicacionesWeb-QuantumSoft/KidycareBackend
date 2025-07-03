using KidycareBackend.Profiles.Domain.Model.Entities;
using KidycareBackend.Profiles.Domain.Model.Queries;

namespace KidycareBackend.Profiles.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
}