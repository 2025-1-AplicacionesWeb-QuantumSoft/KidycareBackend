namespace KidycareBackend.Pay.Domain.Model.Commands;

public record UpdateCardByIdCommand(
    string NumberCard,
    string CardHolder,
    int code,
    int Year,
    int Month    
    );