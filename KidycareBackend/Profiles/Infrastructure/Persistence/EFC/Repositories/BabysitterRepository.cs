using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class BabysitterRepository(AppDbContext context) 
    : BaseRepository<Babysitter>(context), IBabysitterRepository
{
    public async Task<Babysitter?> GetBabysitterId(int babysitterId)
    {
        return await Context.Set<Babysitter>().FirstOrDefaultAsync(b=>b.id == babysitterId);
    }

    public async Task<Babysitter?> GetBabysitterByUserIdQuery(int userId)
    {
        return await Context.Set<Babysitter>().Where(b=>b.UserId==userId).FirstOrDefaultAsync();;
    }

    public async Task<Babysitter?> UpdateBabysitter(Babysitter babysitter)
    {
        var trackedEntity = await Context.Set<Babysitter>().FindAsync(babysitter.id);
        if (trackedEntity == null) return null;
        
        Context.Entry(trackedEntity).CurrentValues.SetValues(babysitter);
        await Context.SaveChangesAsync();
        return trackedEntity;
    }
    
}
