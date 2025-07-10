namespace KidycareBackend.Reviews.Interfaces.Resources;

public record CreateReviewResource(
    int reviewId, int rating, string comment, string parentId, string babysitterId, DateTime date
);