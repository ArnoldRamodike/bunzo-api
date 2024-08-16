namespace papaute.Dtos
{
    public record class GameDetailsDto(
    int Id,
    string Name,
    string Genre,
    Decimal Price,
    DateOnly ReleaseDate,
    string User
    );
}