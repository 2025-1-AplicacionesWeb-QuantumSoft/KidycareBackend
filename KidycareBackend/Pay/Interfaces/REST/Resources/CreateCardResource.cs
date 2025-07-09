namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CreateCardResource(
        int UserId,
        string CardNumber,
        string CardHolder,
        string Cvv,
        string ExpirationDate
    );