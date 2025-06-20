namespace KidycareBackend.Reviews.Interfaces.Resources;

public record CreateReviewResource(
    string reviewApiKey, int rating, string comment, string parentId, string babysitterId, DateTime date
);