namespace KidycareBackend.Pay.Domain.Model.Commands;

public record CreateCardCommand(
    int UserId, 
    string CardNumber,
    string CardHolder,
    string Cvv,
    string ExpirationDate
    );