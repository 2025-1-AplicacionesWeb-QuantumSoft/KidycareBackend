using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.ValueObjects;
using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Domain.Model.Aggregates;

public partial class Card
{
    public long Id { get;  set; }
    public int? ParentId { get; set; }  
    public int? BabysitterId { get; set; }  
    public RCardNumber CardNumber { get;set; }
    public string CardHolder { get;set; }
    public ECvv Cvv { get;set; }
    public ExpirationDateCard ExpirationDate { get;set; }
    
    public Card(int? parentId,int? babysitterId, RCardNumber cardNumber, string cardHolder, ECvv cvv, ExpirationDateCard expirationDate) : this()
    {
        if (parentId != null && babysitterId != null)
        {
            throw new InvalidOperationException("Only one of Parent or Babysitter can be assigned.");
        }
        if (parentId == null && babysitterId == null)
        {
            throw new InvalidOperationException("Either Parent or Babysitter must be assigned.");
        }
        ParentId = parentId;
        BabysitterId = babysitterId;
        CardNumber = cardNumber;
        CardHolder = cardHolder;
        Cvv = cvv;
        ExpirationDate = expirationDate;
    }
    
    public Card()
    {
        ParentId = null;  
        BabysitterId = null; 
        CardNumber = new RCardNumber("0000000000000000");
        CardHolder = string.Empty;
        Cvv = new ECvv(100);
        ExpirationDate = new ExpirationDateCard(1, DateTime.Now.Year);
    }
    
   

    public Card(CreateCardCommand command)
    {
        if (command.ParentId != null && command.BabysitterId != null)
        {
            throw new InvalidOperationException("Only one of ParentId or BabysitterId can be assigned.");
        }

        if (command.ParentId == null && command.BabysitterId == null)
        {
            throw new InvalidOperationException("Either ParentId or BabysitterId must be assigned.");
        }

        ParentId = command.ParentId;
        BabysitterId = command.BabysitterId;
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