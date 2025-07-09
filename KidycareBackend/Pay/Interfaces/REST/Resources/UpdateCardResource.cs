namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record UpdateCardResource(
    string NumberCard,
    string CardHolder,
    int Code,
    int Month,   
    int Year  
    );