namespace KidycareBackend.Reviews.Interfaces.Resources;

public record ReviewResource(int Id, int Rating, string Comment, int ParentId,
        int BabysitterId, DateTime Date)
;