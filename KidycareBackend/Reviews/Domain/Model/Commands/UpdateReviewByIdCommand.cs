namespace KidycareBackend.Reviews.Domain.Model.Commands;

public abstract record UpdateReviewByIdCommand(
    string rating,
    string comment,
    string babysitterId,
    string date
    );