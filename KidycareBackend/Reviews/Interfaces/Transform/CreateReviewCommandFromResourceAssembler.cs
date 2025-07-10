using KidycareBackend.Reviews.Domain.Model.Commands;
using KidycareBackend.Reviews.Interfaces.Resources;

namespace KidycareBackend.Reviews.Interfaces.Transform;

public class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(
        CreateReviewResource resource) => new CreateReviewCommand(
        resource.reviewId,
        resource.rating,
        resource.comment,
        resource.parentId,
        resource.babysitterId,
        resource.date
    );
}