using System.ComponentModel.DataAnnotations;

namespace papaute.Dtos
{
    public record class CreateGameDto(
     [Required][StringLength(50)] string Name,
     int GenreId,
     [Required][Range(1, 100)] Decimal Price,
     DateOnly ReleaseDate,
     string UserId
 );
}