using KidycareBackend.Reservations.Application.Internal.CommandServices;
using KidycareBackend.Reservations.Application.Internal.QueryServices;
using KidycareBackend.Reservations.Domain.Repositories;
using KidycareBackend.Reservations.Domain.Services;
using KidycareBackend.Reservations.Infrastructure.Persistence.EFC.Repositories;
using KidycareBackend.Pay.Application.Internal.CommandServices;
using KidycareBackend.Pay.Application.Internal.QueryServices;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Pay.Infrastruture.Persistence.EFC.Repositories;
using KidycareBackend.RegistrationServices.Application.Internal.CommandServices;
using KidycareBackend.RegistrationServices.Application.Internal.QueryServices;
using KidycareBackend.RegistrationServices.Domain.Repositories;
using KidycareBackend.RegistrationServices.Domain.Services;
using KidycareBackend.RegistrationServices.Infrastructure.Persistence.EFC.Repositories;
using KidycareBackend.Reviews.Application.Internal.CommandServices;
using KidycareBackend.Reviews.Application.Internal.QueryServices;
using KidycareBackend.Reviews.Domain.Repositories;
using KidycareBackend.Reviews.Domain.Services;
using KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Repositories;
using KidycareBackend.Shared.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure kebab-case route naming
builder.Services.AddControllers(options =>
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnet/core/swashbuckle
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify if the connection string is not null or empty
 if (string.IsNullOrEmpty(connectionString))
 {
     throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
 }

// Configure Database Context and Logging Level
 if (builder.Environment.IsDevelopment())
  builder.Services.AddDbContext<AppDbContext>(options =>
  {
   options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
  });
 else  if (builder.Environment.IsProduction())
  builder.Services.AddDbContext<AppDbContext>(options =>
  {
   options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Error)
    .EnableDetailedErrors();
  }); 
 
// Configure Dependency Injection

// Register repositories for Card and Payment
 builder.Services.AddScoped<ICardRepository, CardRepository>();
 builder.Services.AddScoped<ICardQueryService, CardQueryService>();
 builder.Services.AddScoped<ICardCommandService, CardCommandService>();
 
 builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
 builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
 builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();

// Profile bounded context
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
 builder.Services.AddScoped<IReservationCommandService, ReservationCommandService>();
 builder.Services.AddScoped<IReservationQueryService, ReservationQueryService>();
 builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

 builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
 builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
 builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();


 builder.Services.AddCors(options =>
 {
  options.AddPolicy("AllowFrontend",
   policy => policy.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());
 });
 var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
 builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// Verify if the database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var context = services.GetRequiredService<AppDbContext>();
   context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.MapOpenApi();
//}
app.UseCors("AllowFrontend");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
