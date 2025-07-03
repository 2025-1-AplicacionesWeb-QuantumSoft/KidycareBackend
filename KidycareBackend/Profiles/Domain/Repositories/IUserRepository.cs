using KidycareBackend.Profiles.Domain.Model.Entities;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Domain.Repositories;

public interface IUserRepository:IBaseRepository<User>
{
    Task<User?> GetUserByIdAsync(int userId);
    Task<User?> UpdateUserAsync(User user);
}