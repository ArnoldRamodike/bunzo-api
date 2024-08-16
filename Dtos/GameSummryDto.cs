namespace papaute.Dtos
{
  public record class GameSummryDto(
    int Id,
    string Name,
    string Genre,
    Decimal Price,
    DateOnly ReleaseDate,
    string Users
    );
}