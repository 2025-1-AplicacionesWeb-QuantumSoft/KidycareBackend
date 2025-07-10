using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ParentRepository(AppDbContext Context) 
    : BaseRepository<Parent>(Context), IParentRepository
{
    public async Task<Parent?> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Parent>().FirstOrDefaultAsync(p => p.userId == userId);
    }

    public Task<Parent?> Handle(GetParentByIdQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<Parent?> Handle(GetParentByUserIdQuery query)
    {
        return await FindByUserIdAsync(query.UserId);
    }

    public Task<bool> ExistsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}