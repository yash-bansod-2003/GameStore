namespace GameStore.Dtos;

public record class UpdateGameDto(
  String Title,
  String Genre,
  Decimal Price,
  DateOnly ReleaseDate
);