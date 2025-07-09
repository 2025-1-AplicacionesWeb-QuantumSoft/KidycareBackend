using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using KidycareBackend.Reservations.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Reservations.Infrastructure.Persistence.EFC.Repositories;

public class ReservationRepository(AppDbContext Context) 
    : BaseRepository<Reservation>(Context), IReservationRepository
{
    public async Task<Reservation> GetReservationById(int reservationId)
    {
        return await Context.Set<Reservation>().FirstOrDefaultAsync(r => r.Id == reservationId);
    }
    public async Task<Reservation> GetReservationByBabysitterIdAndParentId(BabysitterId babysitterId, ParentId parentId)
    {
        return await Context.Set<Reservation>()
            .FirstOrDefaultAsync(r => r.BabysitterId == babysitterId && r.ParentId == parentId);
    }
    public async Task<IEnumerable<Reservation>> GetReservationsByParentId(ParentId parentId)
    {
        return await Context.Set<Reservation>().Where(r => r.ParentId == parentId).ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByBabysitterId(BabysitterId babysitterId)
    {
        return await Context.Set<Reservation>().Where(r => r.BabysitterId == babysitterId).ToListAsync();
    }

    public async Task<Reservation?> UpdateReservation(Reservation reservation)
    {
        Context.Set<Reservation>().Update(reservation);
        await Context.SaveChangesAsync();
        return reservation;
    }

    public async Task DeleteReservation(int reservationId)
    {
        Context.Set<Reservation>().Remove(await GetReservationById(reservationId));
    }
}