using System;

namespace papaute.Models;

public class Music
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Album { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int Minutes { get; set; }
    public required string UserId { get; set; }
    public Users? User { get; set; }

}
