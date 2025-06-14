using KidycareBackend.Pay.Domain.Model.Commands;

namespace KidycareBackend.Pay.Domain.Model.Aggregates;

public class Card
{
    public int Id { get;  set; }
    public int UserId { get; private set; }
    public string CardNumber { get;private set; }
    public string CardHolder { get;private set; }
    public string Cvv { get;private set; }
    public string ExpirationDate { get;private set; }

    public Card(int userId, string cardNumber, string cardHolder, string cvv, string expirationDate)
    {
        UserId = userId;
        CardNumber = cardNumber;
        CardHolder = cardHolder;
        Cvv = cvv;
        ExpirationDate = expirationDate;
    }

    public Card(CreateCardCommand command)
        : this(command.UserId, command.CardNumber, command.CardHolder, command.Cvv, command.ExpirationDate)
    {
        
    }
}