using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Domain.Model.Entities;

public class Payment
{
    public int Id { get; }
    public decimal Amount { get; private set; }
    public Card Card { get; internal set; }
    public int CardId { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime CreatedAt { get;private set; }
    public int ReservationId { get;private set; }
    public int UserId { get; private set; }

    public Payment(decimal amount, int cardId, PaymentStatus status, DateTime createdAt, int reservationId, int userId)
    {
        Amount = amount;
        CardId = cardId;
        Status = status;
        CreatedAt = createdAt;
        ReservationId = reservationId;
        UserId = userId;
    }

    public Payment(CreatePaymentCommand command) : this(
        command.Amount,command.CardId,command.Status,command.CreatedAt,command.ReservationId,command.UserId
        )
    {
        
    }
}