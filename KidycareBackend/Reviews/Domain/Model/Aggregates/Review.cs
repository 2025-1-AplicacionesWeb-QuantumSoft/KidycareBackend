using KidycareBackend.Reviews.Domain.Model.Commands;

namespace KidycareBackend.Reviews.Domain.Model.Aggregates;

public class Review
{
    public string reviewApiKey { get;  } 

    public string reviewId { get; private set; } //que el nombre coincida con el front 

    public int rating { get;  set; } //
    
    public string comment { get;  set; } //
    
    public string parentId { get; private set; } //
    
    public string babysitterId { get; private set; } //
    
    public DateTime date { get; private set; } //

    protected Review()
    {
        reviewApiKey = string.Empty;
        reviewId = string.Empty;
        rating = 0;
        comment = string.Empty;
        parentId = string.Empty;
        babysitterId = string.Empty;
        date = DateTime.UtcNow;    
    }

    public Review(CreateReviewCommand command)
    {
        reviewApiKey = command.reviewApiKey;
        reviewId = command.reviewId;
        rating = command.rating;
        comment = command.comment;
        parentId = command.parentId;
        babysitterId = command.babysitterId;
        date = command.date;
    }
    
    public void UpdateReview(CreateReviewCommand command)
    {
        rating = command.rating;
        comment = command.comment;
        parentId = command.parentId;
        babysitterId = command.babysitterId;
        date = command.date;
    }
    
    
}