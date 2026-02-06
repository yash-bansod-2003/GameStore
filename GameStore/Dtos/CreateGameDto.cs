using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class CreateGameDto(
  [Required] string Title,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);
