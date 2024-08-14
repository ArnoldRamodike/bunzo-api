using papaute.Dtos;
using papaute.Models;

namespace papaute.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }


        public static GameSummryDto ToGameSummuryDto(this Game game)
        {
            return new(
                   game.Id,
                   game.Name,
                   game.GenreId,
                   game.Price,
                   game.ReleaseDate
               );
        }
        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            return new(
                   game.Id,
                   game.Name,
                   game.GenreId,
                   game.Price,
                   game.ReleaseDate
               );
        }
        public static Game ToGameUpdateDto(this UpdateGameDto game, int id)
        {
            return new Game()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

    }
}