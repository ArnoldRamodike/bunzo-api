using System.ComponentModel.DataAnnotations;

namespace papaute.Dtos;

public record class UpdateMusicDto
(
     [Required][StringLength(50)] string Title,
     string? Album,
    int CategoryId,
    int Minutes,
    string UserId
);
