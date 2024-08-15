using Microsoft.AspNetCore.Identity;

namespace papaute.Models
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public required string UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}