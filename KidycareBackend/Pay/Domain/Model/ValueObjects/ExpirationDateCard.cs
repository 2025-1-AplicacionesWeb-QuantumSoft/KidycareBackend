

namespace KidycareBackend.Pay.Domain.Model.ValueObjects;

public record ExpirationDateCard(string Month, string Year)
{
    public ExpirationDateCard(): this(String.Empty,String.Empty){ }
    
    public ExpirationDateCard(string month) : this(month, string.Empty){ }

    public string Date => $"{Month} / {Year}";
    
    public bool IsValid()
    {
        if (!int.TryParse(Month, out int monthValue) || monthValue < 1 || monthValue > 12)
            return false;

        if (!int.TryParse(Year, out int yearValue) || yearValue <= 2020)
            return false;

        return true;
    }
};