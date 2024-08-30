using papaute.Dtos;
using papaute.Models;

namespace papaute.Mapping;

public static class MusicMapping
{
    public static Music ToEntity(this CreateMusicDto music)
    {
        return new Music()
        {
            Title = music.Title,
            Album = music.Album,
            CategoryId = music.CategoryId,
            Minutes = music.Minutes,
            UserId = music.UserId,
        };
    }

    public static MusicSummuryDto ToMusicSummuryDto(this Music music)
    {
        return new(
            music.Id,
            music.Title,
            music.Album,
            music.Category!.Name,
            music.Minutes,
            music.User!.UserName!
        );

    }
    public static MusicDetailsDto ToMusicDetailsDto(this Music music)
    {
        var categoryName = music.Category?.Name ?? "Unknown Category";
        var userName = music.User?.UserName ?? "Unknown User";
        return new MusicDetailsDto(
            music.Id,
            music.Title,
            music.Album,
            categoryName,
            music.Minutes,
            userName
        );
    }

    public static Music ToMusicUpdateDto(this UpdateMusicDto music, int id)
    {
        return new Music()
        {
            Id = id,
            Title = music.Title,
            Album = music?.Album,
            CategoryId = music.CategoryId,
            Minutes = music.Minutes,
            UserId = music.UserId
        };
    }
}
