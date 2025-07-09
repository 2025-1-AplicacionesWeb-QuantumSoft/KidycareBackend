using KidycareBackend.RegistrationServices.Domain.Model.Aggregates;
using KidycareBackend.RegistrationServices.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.RegistrationServices.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
{
    private readonly AppDbContext _context;

    public ProfileRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Profile>> FindByProfileApiKeyAsync(string profileApiKey)
    {
        return await _context.Set<Profile>()
            .Where(p => p.ProfileApiKey == profileApiKey)
            .ToListAsync();
    }

    public async Task<Profile?> FindByProfileApiKeyAndSourceIdAsync(string profileApiKey, string sourceId)
    {
        return await _context.Set<Profile>()
            .FirstOrDefaultAsync(p => p.ProfileApiKey == profileApiKey && p.SourceId == sourceId);
    }


    public async Task<Profile?> GetProfileSourceById(int profileId)
    {
        return await _context.Set<Profile>()
            .FirstOrDefaultAsync(p => p.Id == profileId);
    }

    public async Task<Profile?> GetProfileSourceByUserId(int userId)
    {
        return await _context.Set<Profile>()
            .FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<Profile?> UpdateProfileSource(Profile profile)
    {
        var existingProfile = await _context.Set<Profile>().FirstOrDefaultAsync(p => p.Id == profile.Id);
        if (existingProfile == null) return null;

        _context.Entry(existingProfile).CurrentValues.SetValues(profile);
        await _context.SaveChangesAsync();
        return existingProfile;
    }

    public async Task DeleteProfileSource(int profileId)
    {
        var profile = await _context.Set<Profile>().FirstOrDefaultAsync(p => p.Id == profileId);
        if (profile != null)
        {
            _context.Set<Profile>().Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
}
