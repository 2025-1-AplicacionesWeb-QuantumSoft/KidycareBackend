using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using KidycareBackend.Reviews.Domain.Model.Commands;

namespace KidycareBackend.Reviews.Domain.Model.Aggregates;

public class Review
{
    //public string reviewApiKey { get;  } 

    public int Id { get; private set; } //que el nombre coincida con el front 

    public int rating { get;  set; } //
    
    public string comment { get;  set; } //
    
    public BabysitterId BabysitterId { get; private set; }
    
    public ParentId ParentId { get; private set; }
    
    public DateTime date { get; private set; } //

    protected Review()
    {
        //reviewApiKey = string.Empty;
        rating = 0;
        comment = string.Empty;
        date = DateTime.UtcNow;    
    }

    public Review(CreateReviewCommand command)
    {
        //reviewApiKey = command.reviewApiKey;
        rating = command.rating;
        comment = command.comment;
        BabysitterId = command.babysitterId;
        ParentId = command.parentId;
        date = command.date;
    }
    
    public void UpdateReview(CreateReviewCommand command)
    {
        rating = command.rating;
        comment = command.comment;
        BabysitterId = command.babysitterId;
        ParentId = command.parentId;
        date = command.date;
    }
    
    
}