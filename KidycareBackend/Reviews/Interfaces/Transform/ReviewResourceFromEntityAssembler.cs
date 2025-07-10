using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Interfaces.Resources;

namespace KidycareBackend.Reviews.Interfaces.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity (Review entity) => new ReviewResource
    (
        entity.reviewId,
        entity.rating,
        entity.comment,
        entity.parentId, 
        entity.babysitterId,
        entity.date
    );
}