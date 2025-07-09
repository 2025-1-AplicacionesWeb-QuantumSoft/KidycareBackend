using KidycareBackend.Reviews.Domain.Model.ValueObjects;
using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Reviews.Domain.Repositories;

public interface IReviewRepository: IBaseRepository<Review>
{
    Task<IEnumerable<Review>> FindByReviewIdAsync(ParentId parentId);
    
    Task<Review?> GetReviewById(int reviewId);
    
    Task<Review> GetReviewByBabysitterIdAndParentId(int babysitterId, int parentId);
    
    Task<Review> UpdateReview(Review review);
    
    Task DeleteReview(int reviewId);
    
}