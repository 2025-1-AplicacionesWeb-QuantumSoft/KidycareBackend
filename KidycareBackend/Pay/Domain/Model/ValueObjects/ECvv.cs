namespace KidycareBackend.Pay.Domain.Model.ValueObjects;

public record ECvv(int Code)
{
    // Constructor con validación
    public int Code { get; init; } = Code < 100 || Code > 999
        ? throw new ArgumentException("El código CVV debe tener 3 dígitos.")
        : Code;
};