using KidycareBackend.Reviews.Domain.Model.Commands;
using KidycareBackend.Reviews.Interfaces.Resources;

namespace KidycareBackend.Reviews.Interfaces.Transform;

public class UpdateReviewByIdCommandFromResourceAssembler
{
    public static UpdateReviewByIdCommand ToCommandFromResource(
        UpdateReviewResource resource, string reviewApiKey)
    {
        return new UpdateReviewByIdCommand(
            resource.rating,
            resource.comment,
            resource.babysitterId,
            resource.date
        );
        
    }

}