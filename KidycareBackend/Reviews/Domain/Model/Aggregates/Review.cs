using KidycareBackend.Reviews.Domain.Model.Commands;

namespace KidycareBackend.Reviews.Domain.Model.Aggregates;

public class Review
{
    public int reviewId { get; private set; }

    public int rating { get; private set; }
    
    public string comment { get; private set; }
    
    public string parentId { get; private set; }
    
    public string babysitterId { get; private set; }
    
    public DateTime date { get; private set; }

    protected Review()
    {
        reviewId = 0;
        rating = 0;
        comment = string.Empty;
        parentId = string.Empty;
        babysitterId = string.Empty;
        date = DateTime.MinValue;    
    }

    public Review(CreateReviewCommand command)
    {
        reviewId = command.reviewId;
        rating = command.rating;
        comment = command.comment;
        parentId = command.parentId;
        babysitterId = command.babysitterId;
        date = command.date;
    }
}