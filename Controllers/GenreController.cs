using papaute.Dtos;
using papaute.Models;

namespace papaute.Controllers
{
    public static class GenreController
    {
        public static GenreDto ToEntity(this Genre genre)
        {
            return new GenreDto(
                genre.Id, genre.Name
            );
        }
    }
}