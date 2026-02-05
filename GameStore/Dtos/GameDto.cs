namespace GameStore.Dtos;

public record class GameDto
{
  public int Id { get; init; }
  public string Title { get; init; } = string.Empty;
  public string Genre { get; init; } = string.Empty;
  public decimal Price { get; init; }
  public DateOnly ReleaseDate { get; init; }
}
