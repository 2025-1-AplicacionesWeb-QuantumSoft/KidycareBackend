namespace KidycareBackend.Reviews.Interfaces.Resources;

public record CreateReviewResource(
    int Id, int rating, string comment, int parentId, int babysitterId, DateTime date
);