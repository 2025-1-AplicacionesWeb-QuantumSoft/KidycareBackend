using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Interfaces.Resources;

namespace KidycareBackend.Reviews.Interfaces.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity (Review entity) => new ReviewResource
    (
        entity.Id,
        entity.rating,
        entity.comment,
        entity.ParentId, 
        entity.BabysitterId,
        entity.date
    );
}