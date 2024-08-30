

using Microsoft.EntityFrameworkCore;
using papaute.Data;
using papaute.Dtos;
using papaute.Mapping;
using papaute.Models;

namespace papaute.Controllers
{
    public static class MusicController
    {
        const string GetMusicEndpointName = "GetMusic";

        public static RouteGroupBuilder MapMusicController(this WebApplication app)
        {
            var group = app.MapGroup("/api/music");

            // Get Music
            group.MapGet("/", async (AppDbContext dbContext) =>
             await dbContext.Music
             .Include(music => music.Category)
             .Include(music => music.User)
             .Select(music => music.ToMusicSummuryDto())
             .AsNoTracking()
             .ToListAsync()
            );

            // Get Music
            group.MapGet("/{id}", async (int id, AppDbContext dbContext) =>
            {
                Music? music = await dbContext.Music
                .Include(m => m.Category)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
                return music is null ? Results.NotFound() : Results.Ok(music.ToMusicDetailsDto());
            })
            .WithName(GetMusicEndpointName);

            // Post Music
            group.MapPost("/", async (CreateMusicDto newMusic, AppDbContext dbContext) =>
                {

                    Music music = newMusic.ToEntity();

                    await dbContext.Music.AddAsync(music);
                    await dbContext.SaveChangesAsync();

                    music = await dbContext.Music.Include(m => m.Category).Include(g => g.User).FirstOrDefaultAsync(g => g.Id == music.Id);

                    return Results.CreatedAtRoute(GetMusicEndpointName, new { id = music.Id }, music.ToMusicDetailsDto());
                });

            // Put Games
            group.MapPut("/{id}", async (int id, UpdateMusicDto updateMusic, AppDbContext dbContext) =>
            {
                var existingMusic = await dbContext.Music.FindAsync(id);

                if (existingMusic is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingMusic)
                        .CurrentValues
                        .SetValues(updateMusic.ToMusicUpdateDto(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            // Delete Music
            group.MapDelete("/{id}", async (AppDbContext dbContext, int id) =>
            {
                await dbContext.Music
                              .Where(music => music.Id == id)
                              .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
