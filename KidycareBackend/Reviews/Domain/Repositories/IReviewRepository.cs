using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Reviews.Domain.Repositories;

public interface IReviewRepository: IBaseRepository<Review>
{
    Task<IEnumerable<Review>> GetReviewByParentId(int parentId);
    
    Task<IEnumerable<Review>> GetReviewByBabysitterId(int babysitterId);
    
    Task<Review> GetReviewById(int reviewId);
    
    Task<Review> GetReviewByBabysitterIdAndParentId(object babysitterId, object parentId);
    
    Task<Review> UpdateReview(Review reviewId);
    
    Task DeleteReview(int reviewId);
}