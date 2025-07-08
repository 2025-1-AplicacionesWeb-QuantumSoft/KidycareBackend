namespace KidycareBackend.Pay.Domain.Model.Commands;

public record CreateCardCommand(
    int UserId,   
    string NumberCard,
    string CardHolder,
    int code,
    int Year,
    int Month   
    );