using GameStore.Dtos;

namespace GameStore.Endpoints;

public class GamesEndpoints
{
  private static readonly List<GameDto> games = [
    new GameDto
    {
        Id = 1,
        Title = "The Legend of Code",
        Genre = "Adventure",
        Price = 59.99m,
        ReleaseDate = new DateOnly(2023, 11, 15)
    },
    new GameDto
    {
        Id = 2,
        Title = "Debugging Quest",
        Genre = "RPG",
        Price = 49.99m,
        ReleaseDate = new DateOnly(2024, 2, 20)
    }
  ];

  public static void MapEndpoints(WebApplication app)
  {
    var group = app.MapGroup("/games");

    group.MapGet("/", () => games);

    group.MapGet("/{id}", (int id) =>
    {
      var game = games.FirstOrDefault(g => g.Id == id);
      return game is not null ? Results.Ok(game) : Results.NotFound();
    });

    group.MapPost("/", (CreateGameDto newGame) =>
    {
      var game = new GameDto
      {
        Id = games.Count + 1,
        Title = newGame.Title,
        Genre = newGame.Genre,
        Price = newGame.Price,
        ReleaseDate = newGame.ReleaseDate
      };
      games.Add(game);
      return Results.Created($"/{game.Id}", game);
    });

    group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
    {
      var index = games.FindIndex(g => g.Id == id);
      if (index == -1)
      {
        return Results.NotFound();
      }
      var updatedGameDto = new GameDto
      {
        Id = id,
        Title = updatedGame.Title,
        Genre = updatedGame.Genre,
        Price = updatedGame.Price,
        ReleaseDate = updatedGame.ReleaseDate
      };
      games[index] = updatedGameDto;
      return Results.Ok(updatedGameDto);
    });

    group.MapDelete("/{id}", (int id) =>
    {
      var index = games.FindIndex(g => g.Id == id);
      if (index == -1)
      {
        return Results.NotFound();
      }
      games.RemoveAt(index);
      return Results.NoContent();
    });
  }
}
