using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

GamesEndpoints.MapEndpoints(app);

app.Run();
