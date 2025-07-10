using KidycareBackend.Reviews.Domain.Model.Aggregates;
            using KidycareBackend.Reviews.Domain.Repositories;
            using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
            using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
            using Microsoft.EntityFrameworkCore;
            
            namespace KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Repositories;
            
            public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
            {
                public async Task<IEnumerable<Review>> GetReviewByParentId(int parentId)
                {
                    return await Context.Set<Review>().Where(r => r.parentId == parentId.ToString()).ToListAsync();
                }
            
                public async Task<IEnumerable<Review>> GetReviewByBabysitterId(int babysitterId)
                {
                    return await Context.Set<Review>().Where(r => r.babysitterId == babysitterId.ToString()).ToListAsync();
                }
            
                public async Task<Review> GetReviewById(int reviewId)
                {
                    return await Context.Set<Review>().FirstOrDefaultAsync(r => r.reviewId == reviewId);
                }
            
                public async Task<Review> GetReviewByBabysitterIdAndParentId(object babysitterId, object parentId)
                {
                    return await Context.Set<Review>().FirstOrDefaultAsync(r => r.babysitterId == babysitterId && r.parentId == parentId);
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