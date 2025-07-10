namespace KidycareBackend.Reviews.Interfaces.Resources;

public record ReviewResource(
    int reviewId, int rating, string comment, string parentId, string babysitterId, DateTime date
);