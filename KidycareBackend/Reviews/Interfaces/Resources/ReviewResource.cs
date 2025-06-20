namespace KidycareBackend.Reviews.Interfaces.Resources;

public record ReviewResource(string ReviewApiKey, string ReviewId, int Rating, string Comment, string ParentId,
        string BabysitterId, DateTime Date)
;