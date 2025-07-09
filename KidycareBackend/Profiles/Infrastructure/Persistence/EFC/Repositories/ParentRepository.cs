using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ParentRepository(AppDbContext Context) 
    : BaseRepository<Parent>(Context), IParentRepository
{
    public Task<Parent?> FindByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Parent?> Handle(GetParentByIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Parent?> Handle(GetParentByUserIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}