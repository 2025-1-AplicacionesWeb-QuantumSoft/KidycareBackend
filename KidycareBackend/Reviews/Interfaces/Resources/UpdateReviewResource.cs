namespace KidycareBackend.Reviews.Interfaces.Resources;

public record UpdateReviewResource(
    int rating,
    string comment,
    DateTime date
    );