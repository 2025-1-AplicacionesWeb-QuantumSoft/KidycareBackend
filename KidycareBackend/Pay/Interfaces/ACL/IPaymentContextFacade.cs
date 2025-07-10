namespace KidycareBackend.Pay.Interfaces.ACL;

public interface IPaymentContextFacade
{
    Task<int> CreatePayment(
        decimal Amount,
        long CardId,
        DateTime CreatedAtDate,
        int ReservationId,
        int ParentId);
}