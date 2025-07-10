namespace KidycareBackend.Reviews.Domain.Model.Commands;

public record CreateReviewCommand(
    int reviewId,
    int rating,
    string comment,
    string parentId,
    string babysitterId,
    DateTime date
);



    
