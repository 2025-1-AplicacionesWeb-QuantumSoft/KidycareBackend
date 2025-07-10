using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Model.Queries;
using KidycareBackend.Reviews.Domain.Repositories;
using KidycareBackend.Reviews.Domain.Services;

namespace KidycareBackend.Reviews.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository) 
    : IReviewQueryService
{
    public async Task<IEnumerable<Review>> Handle(GetAllReviewsByParentIdQuery query)
    {
        return await reviewRepository.FindByReviewIdAsync(query.parentId);
    }

    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.GetReviewById(query.Id);
    }
}