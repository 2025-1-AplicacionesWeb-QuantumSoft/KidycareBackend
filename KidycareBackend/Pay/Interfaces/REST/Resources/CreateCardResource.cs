namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CreateCardResource(
        int? ParentId,  
        int? BabysitterId,
        string NumberCard,
        string CardHolder,
        int Code,
        int Month,   
        int Year
    );