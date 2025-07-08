using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.ValueObjects;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Domain.Model.Aggregates;

public partial class Card
{
    public long Id { get;  set; }
    public int UserId { get; set; }
    public RCardNumber CardNumber { get;set; }
    public string CardHolder { get;set; }
    public ECvv Cvv { get;set; }
    public ExpirationDateCard ExpirationDate { get;set; }
    
    public Card(int userId, RCardNumber cardNumber, string cardHolder, ECvv cvv, ExpirationDateCard expirationDate) : this()
    {
        UserId = userId;
        CardNumber = cardNumber;
        CardHolder = cardHolder;
        Cvv = cvv;
        ExpirationDate = expirationDate;
    }
    
    public Card()
    {
        CardNumber = new RCardNumber("0000000000000000");
        CardHolder = string.Empty;
        Cvv = new ECvv(100);
        ExpirationDate = new ExpirationDateCard(1, DateTime.Now.Year);
    }
    
   

    public Card(CreateCardCommand command)
    {
        UserId = command.UserId;
        CardNumber = new RCardNumber(command.NumberCard);
        CardHolder = command.CardHolder;
        Cvv = new ECvv(command.code);
        ExpirationDate = new ExpirationDateCard(command.Month, command.Year);
    }

    public void UpdateCard(UpdateCardByIdCommand command)
    {
        CardNumber = new RCardNumber(command.NumberCard);
        CardHolder = command.CardHolder;
        Cvv = new ECvv(command.code);
        ExpirationDate = new ExpirationDateCard(command.Month, command.Year);
    }
}