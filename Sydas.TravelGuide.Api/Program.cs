using System.Reflection;
using Sydas.Framework.AspNetCore.Endpoints;
using Sydas.TravelGuide.Api.Exceptions;
using Sydas.TravelGuide.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.RegisterEndpoints(Assembly.GetExecutingAssembly());

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.Run();

