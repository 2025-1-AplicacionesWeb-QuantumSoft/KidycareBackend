using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class BabysitterRepository(AppDbContext Context) 
    : BaseRepository<Babysitter>(Context), IBabysitterRepository
{
    public Task<Babysitter?> FindByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Babysitter?> Handle(GetBabysitterByIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Babysitter?> Handle(GetBabysitterByUserIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
