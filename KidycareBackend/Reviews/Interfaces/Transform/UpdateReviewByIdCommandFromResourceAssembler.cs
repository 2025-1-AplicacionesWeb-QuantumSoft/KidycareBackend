using KidycareBackend.Reviews.Domain.Model.Commands;
using KidycareBackend.Reviews.Interfaces.Resources;

namespace KidycareBackend.Reviews.Interfaces.Transform;

public class UpdateReviewByIdCommandFromResourceAssembler
{
    public static UpdateReviewByIdCommand ToCommandFromResource(
        UpdateReviewResource resource, int Id)
    {
        return new UpdateReviewByIdCommand(
            resource.rating,
            resource.comment,
            resource.date
        );
        
    }

}