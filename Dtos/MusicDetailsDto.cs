namespace papaute.Dtos;

public record class MusicDetailsDto
(
     int Id,
     string Title,
     string? Album,
     string Category,
     int Minutes,
     string User
);