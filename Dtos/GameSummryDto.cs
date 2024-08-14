namespace papaute.Dtos
{
  public record class GameSummryDto(
    int Id,
    string Name,
    int GenreId,
    Decimal Price,
    DateOnly ReleaseDate
    );
}