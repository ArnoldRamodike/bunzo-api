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
                ReleaseDate = game.ReleaseDate,
                UserId = game.UserId,
            };
        }


        public static GameSummryDto ToGameSummuryDto(this Game game)
        {
            return new(
                   game.Id,
                   game.Name,
                   game.Genre!.Name,
                   game.Price,
                   game.ReleaseDate,
                   game.User!.UserName!
               );
        }
        public static UserSummryDto ToUserSummryDto(this Users game)
        {
            return new(
                   game.Id,
                   game.UserName!,
                   game.Email!,
                   game.FullName!
               );
        }
        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            var genreName = game.Genre?.Name ?? "Unknown Genre";
            var userName = game.User?.UserName ?? "Unknown User";

            return new GameDetailsDto(
                game.Id,
                game.Name,
                genreName,
                game.Price,
                game.ReleaseDate,
                userName
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
                ReleaseDate = game.ReleaseDate,
                UserId = game.UserId
            };
        }

    }
}