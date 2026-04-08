using Acme.Hello.Platform.Generic.Domain.Model.Entities;
using Acme.Hello.Platform.Generic.Interfaces.REST.Assemblers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGet(pattern: "greetings", (string? firstName, string? lastnName) =>
{
    var developer = !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastnName)
        ? new Developer(firstName, lastnName)
        : null;
    var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
    return Results.Ok(response);
}).WithName("GetGreeting");

app.MapPost(pattern: "/greetings", (GreetDeveloperRequest request) =>
{
    var developer = DeveloperAssembler.ToEntityFromRequest(request);
    var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
    return Results.Ok(response);
}).WithName("PostGreeting");

app.Run();
