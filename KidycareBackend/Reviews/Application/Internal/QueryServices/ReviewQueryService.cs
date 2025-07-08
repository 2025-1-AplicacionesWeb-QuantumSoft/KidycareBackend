using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Model.Queries;
using KidycareBackend.Reviews.Domain.Repositories;
using KidycareBackend.Reviews.Domain.Services;

namespace KidycareBackend.Reviews.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository) 
    : IReviewQueryService
{
    public Task<IEnumerable<Review>> Handle(GetAllReviewsByParentIdQuery query)
    {
        throw new NotImplementedException();
    }

    

    public Task<IEnumerable<Review>> Handle(GetReviewByIdQuery query)
    {
        throw new NotImplementedException();
    }
}