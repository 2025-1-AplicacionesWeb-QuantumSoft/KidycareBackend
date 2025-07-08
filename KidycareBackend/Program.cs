using System.Text;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using KidycareBackend.IAM.Application.Internal.CommandServices;
using KidycareBackend.IAM.Application.Internal.OutboundServices;
using KidycareBackend.IAM.Application.Internal.QueryServices;
using KidycareBackend.IAM.Domain.Repositories;
using KidycareBackend.IAM.Domain.Services;
using KidycareBackend.IAM.Infrastructure.Hashing.BCrypt.Services;
using KidycareBackend.IAM.Infrastructure.Persistence.EFC.Repositories;
using KidycareBackend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using KidycareBackend.IAM.Infrastructure.Tokens.JWT.Configuration;
using KidycareBackend.IAM.Infrastructure.Tokens.JWT.Services;
using KidycareBackend.IAM.Interfaces.ACL;
using KidycareBackend.IAM.Interfaces.ACL.Services;
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
using KidycareBackend.Profiles.Application.ACL;
using KidycareBackend.Profiles.Application.Internal.CommandServices;
using KidycareBackend.Profiles.Application.Internal.QueryServices;
using KidycareBackend.Profiles.Domain.Repositories;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;
using KidycareBackend.Profiles.Interfaces.ACL;
using KidycareBackend.Profiles.Interfaces.REST.Resources;
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
using KidycareBackend.Shared.Infrastructure.Mediator.Cortex.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen(options =>
 {
  options.EnableAnnotations();
  options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
   In = ParameterLocation.Header,
   Description = "Please enter token",
   Name = "Authorization",
   Type = SecuritySchemeType.Http,
   BearerFormat = "JWT",
   Scheme = "bearer"
  });
  options.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
   {
    new OpenApiSecurityScheme
    {
     Reference = new OpenApiReference
     {
      Id = "Bearer",
      Type = ReferenceType.SecurityScheme
     }
    },
    Array.Empty<string>()
   }
  });
 });

 builder.Services.AddCors(options =>
 {
  options.AddPolicy("AllowFrontend",
   policy => policy.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());
 });
// Configure Dependency Injection

// User Bounded Context Configuration

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

builder.Services.AddScoped<IBabysitterCommandService, BabysitterCommandService>();
 builder.Services.AddScoped<IBabysitterQueryService, BabysitterQueryService>();
builder.Services.AddScoped<IBabysitterRepository, BabysitterRepository>();

builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

builder.Services.AddScoped<IParentQueryService, ParentQueryService>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IParentCommandService, ParentCommandService>();

// TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
 builder.Services.AddScoped< IUserRepository, UserRepository>();
 builder.Services.AddScoped<IUserQueryService, UserQueryService>();
 builder.Services.AddScoped<IUserCommandService, UserCommandService>();
 builder.Services.AddScoped<ITokenService, TokenService>();
 builder.Services.AddScoped<IHashingService, HashingService>();
 builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
 
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
 /*var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
 builder.WebHost.UseUrls($"http://0.0.0.0:{port}");*/
 builder.Services.AddCortexMediator(
  configuration: builder.Configuration,
  handlerAssemblyMarkerTypes: new[] { typeof(Program) }, configure: options =>
  {
   options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
  });


 /*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
   var secretKey = builder.Configuration["TokenSettings:Secret"];
   options.TokenValidationParameters = new TokenValidationParameters
   {
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
   };
  });*/

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
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");
//app.UseAuthentication();
app.UseRequestAuthorization();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
