using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Model.Commands;

namespace KidycareBackend.Reviews.Domain.Services;

public interface IReviewCommandService
{
    Task<Review> Handle(CreateReviewCommand command);
    
    Task<Review> Handle(UpdateReviewByIdCommand byIdCommand, int reviewId);
    
    Task<Review> Handle(DeleteReviewByIdCommand byIdCommand);
    
}