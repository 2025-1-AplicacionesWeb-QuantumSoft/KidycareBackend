using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.Queries;
using KidycareBackend.Reservations.Domain.Services;
using KidycareBackend.Reservations.Interfaces.ACL;

namespace KidycareBackend.Reservations.Application.ACL;

public class ReservationContextFacade(IReservationQueryService reservationQueryService)
    : IReservationContextFacade
{
    public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
    {
        return await reservationQueryService.handle(new GetReservationByIdQuery(reservationId));
    }

    public async Task<IEnumerable<Reservation?>> GetAllReservationsAsync()
    {
        return await reservationQueryService.handle(new GetAllReservationsQuery());
    }
}