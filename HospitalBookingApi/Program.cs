using System.Collections.Generic;
using HospitalBookingApi.Data;
using HospitalBookingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
           .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Built-in OpenAPI generator
builder.Services.AddOpenApi();

// Add Swashbuckle for Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Hospital Booking API v1");
        options.RoutePrefix = "swagger";
    });
}

// app.UseHttpsRedirection(); // Disabled for local development consistency

app.UseCors();

app.UseAuthorization();

app.MapControllers();

// Automatic Database Initialization
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        Console.WriteLine("--- Initializing Database ---");
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();

        DbInitializer.Seed(context);
        Console.WriteLine("--- Database initialized successfully ---");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "--- DATABASE ERROR ---");
        Console.WriteLine("ERROR: Database initialization failed.");
    }
}

Console.WriteLine("--- Hospital Booking API: http://localhost:5237 ---");
app.Run();