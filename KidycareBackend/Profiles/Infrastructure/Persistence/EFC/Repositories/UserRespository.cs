using KidycareBackend.Profiles.Domain.Model.Entities;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class UserRespository(AppDbContext context):BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return Context.Set<User>().FirstOrDefault(u => u.Id == userId);
    }

    public async Task<User?> UpdateUserAsync(User user)
    {
        Context.Set<User>().Update(user);
        await Context.SaveChangesAsync();
        return user;
    }
}