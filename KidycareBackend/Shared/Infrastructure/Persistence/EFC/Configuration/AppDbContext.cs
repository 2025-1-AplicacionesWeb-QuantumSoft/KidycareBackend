using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using KidycareBackend.Pay.Infrastruture.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using KidycareBackend.RegistrationServices.Infrastructure.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Reservations.Infrastructure.Persistence.EFC.Configuration.Extensions;
using KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyCardConfiguration();
        builder.ApplyReservationConfiguration();
        builder.ApplyRegistrationServicesConfiguration();
        builder.ApplyReviewsConfiguration();
        
        builder.UseSnakeCaseNamingConvention();
        
    }
}