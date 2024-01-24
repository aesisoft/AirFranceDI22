using AirFranceAPI.Middleware;
using AirFranceDI22Model.Context;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

//chaine de connexion
string connexionString = builder.Configuration.GetConnectionString("MainConnexionString") ??
    throw (new Exception("Connection string is missing"));

builder.Services.AddDbContext<AirFranceDI22Context>(options => options
        .UseMySql(connexionString, ServerVersion.AutoDetect(connexionString)));

// Add services to the container.
builder.Services.AddScoped<AirFranceDI22Context>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration nLog
builder.Logging.ClearProviders();
builder.Logging.AddNLog("NLog.config");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();

app.Run();
