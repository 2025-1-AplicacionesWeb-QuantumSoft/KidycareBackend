namespace KidycareBackend.Reviews.Domain.Model.Commands;

public record UpdateReviewByIdCommand(
    int rating,
    string comment,
    string babysitterId,
    DateTime date
    );