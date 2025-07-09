namespace KidycareBackend.Reviews.Interfaces.Resources;

public record ReviewResource(
    string reviewApiKey, string reviewId, int rating, string comment, string parentId, string babysitterId, DateTime date
);