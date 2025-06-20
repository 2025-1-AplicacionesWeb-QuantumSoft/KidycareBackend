namespace KidycareBackend.Reviews.Domain.Model.Commands;

public record CreateReviewCommand(
    string reviewApiKey,
    string reviewId,
    int rating,
    string comment,
    string parentId,
    string babysitterId,
    DateTime date
);



    
