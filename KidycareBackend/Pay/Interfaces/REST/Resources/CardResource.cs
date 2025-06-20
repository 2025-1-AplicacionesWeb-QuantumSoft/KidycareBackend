namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CardResource(
    int Id,
    int UserId,
    string CardNumber,
    string CardHolder,
    string Cvv,
    string ExpirationDate
    );