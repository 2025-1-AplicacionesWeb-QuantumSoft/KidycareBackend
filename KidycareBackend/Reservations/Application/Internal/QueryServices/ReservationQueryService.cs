using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.Queries;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using KidycareBackend.Reservations.Domain.Repositories;
using KidycareBackend.Reservations.Domain.Services;

namespace KidycareBackend.Reservations.Application.Internal.QueryServices;

public class ReservationQueryService(IReservationRepository reservationRepository)
: IReservationQueryService
{
    public async Task<IEnumerable<Reservation>> handle(GetAllReservationByParentIdQuery query)
    {
        return await reservationRepository.GetReservationsByParentId(query.ParentId);
    }

    public async Task<IEnumerable<Reservation>> handle(GetAllReservationByBabysitterIdQuery query)
    {
        return await reservationRepository.GetReservationsByBabysitterId(query.BabysitterId);
    }
    
    public async Task<Reservation?> handle(GetReservationByIdQuery query)
    {
        return await reservationRepository.FindByIdAsync(query.id);
    }
    
    public async Task<IEnumerable<Reservation>> handle(GetAllReservationsQuery query)
    {
        return await reservationRepository.ListAsync();
    }
}