namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CreateCardResource(
        int UserId,
        string NumberCard,
        string CardHolder,
        int Code,
        int Month,   
        int Year
    );