using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Domain.Model.Aggregates;

public partial class Payment
{
    public int Id { get; }
    public decimal Amount { get; set; }
    
    public Card? Card { get; internal set; } // Propiedad de navegación (opcional si deseas acceder a los detalles de la tarjeta)
    public long CardId { get; private set; } // Clave foránea hacia Card
    public PaymentStatus Status { get; private set; }
    public DateTime? CreatedAtDate { get;private set; }
    public int ReservationId { get;private set; }
    public int ParentId { get; private set; }

    
    public Payment(decimal amount, long cardId, PaymentStatus status, DateTime createdAt, int reservationId, int parentId): this()
    {
        Amount = amount;
        CardId = cardId;
        Status = status;
        CreatedAtDate = createdAt;
        ReservationId = reservationId;
        ParentId = parentId;
    }

    public Payment()
    {
        Amount = 0;
        Status = PaymentStatus.Pendiente;
        CreatedAtDate = DateTime.Now;
        CardId = 0;
        Card = null;
    }

    public Payment(CreatePaymentCommand command, Card Card)
    {
        Amount = command.Amount;
        CardId = command.CardId;
        Status = PaymentStatus.Pendiente;
        CreatedAtDate = DateTime.Now;
        ReservationId = command.ReservationId;
        ParentId = command.ParentId;
        Card = Card;
    }
    
    public void MarkAsPaid()
    {
        if (Status == PaymentStatus.Pendiente)
        {
            Status = PaymentStatus.Completado;  // Cambiar el estado a "Pagado"
        }
        else
        {
            Status = PaymentStatus.Cancelado;
        }
    }
    
}