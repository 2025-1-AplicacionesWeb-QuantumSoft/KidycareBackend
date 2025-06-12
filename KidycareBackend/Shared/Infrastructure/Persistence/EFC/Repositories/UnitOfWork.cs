using KidycareBackend.Shared.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}