using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ParentRepository(AppDbContext context) 
    : BaseRepository<Parent>(context), IParentRepository
{
    public async Task<Parent?> GetParentById(int parentId)
    {
        return await Context.Set<Parent>().FirstOrDefaultAsync(p=>p.Id == parentId); 
    }

    public async Task<Parent?> GetParentByUserId(int userId)
    {
        return await Context.Set<Parent>().Where(p => p.userId==userId).FirstOrDefaultAsync();
    }

    public async Task<Parent?> UpdateParent(Parent parent)
    {
        var trackedEntity = await Context.Set<Parent>().FindAsync(parent.Id);
        if (trackedEntity == null) return null;
        
        Context.Entry(trackedEntity).CurrentValues.SetValues(parent);
        await Context.SaveChangesAsync();
        return trackedEntity;
    }
}