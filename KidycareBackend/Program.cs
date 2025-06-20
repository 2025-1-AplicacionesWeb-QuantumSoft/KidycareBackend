using KidycareBackend.Reviews.Application.Internal.CommandServices;
using KidycareBackend.Reviews.Application.Internal.QueryServices;
using KidycareBackend.Reviews.Domain.Repositories;
using KidycareBackend.Reviews.Domain.Services;
using KidycareBackend.Reviews.Infrastructure.Repositories;
using KidycareBackend.Shared.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

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

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();