using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reviews.Domain.Model.Commands;

public record CreateReviewCommand(
    //string reviewApiKey,
    int Id,
    int rating,
    string comment,
    ParentId parentId,
    BabysitterId babysitterId,
    DateTime date
);



    
