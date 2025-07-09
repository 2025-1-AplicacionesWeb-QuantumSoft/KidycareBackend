namespace KidycareBackend.Pay.Domain.Model.ValueObjects;

public record RCardNumber(string NumberCard)
{
    public string Number { get; init; } = (NumberCard.Length == 16)
        ? NumberCard
        : throw new ArgumentException("El número de la tarjeta debe tener 16 dígitos.");
};