using Microsoft.AspNetCore.Mvc;

namespace Lofi.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private static readonly string[] listOfGenres = new[]
    {
        "Jazz", "Rock", "Hip-Hop", "RnB", "Afro-Beat", "Jazz Rap", "Blues", "Folk", "Country", "House"
    };

    private readonly ILogger<Genre> _logger;

    public GenreController(ILogger<Genre> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRandomGenre")]
    public IEnumerable<Genre> Get()
    {
        _logger.LogInformation("Generating random genre's...");
        return Enumerable.Range(1, 3).Select(index => new Genre
        {
            
            genre = listOfGenres[Random.Shared.Next(listOfGenres.Length)]
        })
        .ToArray();
    }
}

