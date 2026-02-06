using GameStore.Data;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connectionString = "Data Source=GameStore.db";

builder.Services.AddSqlite<GameStoreContext>(connectionString);

var app = builder.Build();

GamesEndpoints.MapEndpoints(app);

app.Run();
