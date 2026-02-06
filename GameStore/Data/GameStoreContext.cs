
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

// Perpose of this class is to represent the database context for the GameStore application. It will be used to interact with the database and perform CRUD operations on the game data. This class will typically inherit from DbContext and include DbSet properties for each entity in the application, such as Game, Genre, etc. It will also include configuration for the database connection and any necessary model configurations.

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
  public DbSet<Game> Games { get; set; }
}
