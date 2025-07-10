using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Model.Queries;

namespace KidycareBackend.Reviews.Domain.Services;

public interface IReviewQueryService
{
    Task <IEnumerable<Review>> Handle(GetAllReviewsByParentIdQuery query);
    
    Task <Review?> Handle(GetReviewByIdQuery query);
}