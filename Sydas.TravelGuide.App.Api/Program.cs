using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Sydas.Framework.AspNetCore.Endpoints;
using Sydas.Framework.DependencyInjection;
using Sydas.Framework.SemanticKernel.Options;
using Sydas.TravelGuide.App.Api.Exceptions;
using Sydas.TravelGuide.App.Api.Extensions;
using Sydas.TravelGuide.App.Application.Commands.Itinerary;
using Sydas.TravelGuide.App.Application.Kernels;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSemanticKernel();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
// builder.Services.AddMediatR(configuration =>
// {
//     configuration.RegisterServicesFromAssembly(typeof(GenerateItinerary).Assembly);
// });

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

