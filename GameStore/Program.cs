using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

GamesEndpoints.MapEndpoints(app);

app.Run();
