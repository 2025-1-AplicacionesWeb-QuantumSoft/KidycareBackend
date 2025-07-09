using KidycareBackend.Reviews.Domain.Model.ValueObjects;
using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    public async Task<IEnumerable<Review>> FindByReviewIdAsync(ParentId parentId)
    {
        return await Context.Set<Review>().
            Where(r => r.ParentId==parentId).
            ToListAsync();
    }

    

    public async Task<Review?> GetReviewById(int reviewId)
    {
        return await Context.Set<Review>().
            FirstOrDefaultAsync(r => r.Id == reviewId); 
    }
    
    public async Task<Review> GetReviewByBabysitterIdAndParentId(int babysitterId, int parentId)
    {
        return await Context.Set<Review>().
            FirstOrDefaultAsync(r => r.BabysitterId == babysitterId && r.ParentId == parentId);
    }

    public async Task<Review> UpdateReview(Review reviewId)
    {
        Context.Set<Review>().Update(reviewId);
        await Context.SaveChangesAsync();
        return reviewId;
    }
    
    public async Task DeleteReview(int reviewId)
    {
        Context.Set<Review>().Remove(await GetReviewById(reviewId));
    }
}