namespace KidycareBackend.Pay.Domain.Model.Commands;

public record CreateCardCommand(
    int? ParentId,          
    int? BabysitterId,  
    string NumberCard,
    string CardHolder,
    int code,
    int Year,
    int Month   
    );