

using System.Data;

namespace KidycareBackend.Pay.Domain.Model.ValueObjects;

public record ExpirationDateCard(int Month, int Year )
{
    // Constructor sin parámetros
    public ExpirationDateCard() : this(1, DateTime.Now.Year) { }

    // Constructor con parámetros
    public ExpirationDateCard(int month) : this(month, DateTime.Now.Year) { }

    // Propiedad para obtener la fecha
    public string Date => $"{Month:D2} / {Year}";

    // Validación
    public bool IsValid()
    {
        // Validación para el mes
        if (Month < 1 || Month > 12)
            return false;

        // Validación para el año
        if (Year < DateTime.Now.Year || (Year == DateTime.Now.Year && Month < DateTime.Now.Month))
            return false;

        return true;
    }
};