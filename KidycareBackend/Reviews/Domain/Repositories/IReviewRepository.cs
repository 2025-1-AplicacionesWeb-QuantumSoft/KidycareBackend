using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Reviews.Domain.Repositories;

public interface IReviewRepository: IBaseRepository<Review>
{
    Task<IEnumerable<Review>> GetReviewByParentId(string parentId);
    
    Task<Review> GetReviewById(string reviewId);
    
    Task<Review> GetReviewByBabysitterIdAndParentId(object babysitterId, object parentId);
    
    Task<Review> UpdateReview(Review reviewId);
    
    Task DeleteReview(string reviewId);
}