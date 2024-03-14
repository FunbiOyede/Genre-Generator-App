using Microsoft.AspNetCore.Mvc;

namespace Lofi.Controllers;

[Route("api/[controller]")]
public class GenreController : Controller
{
    // private static readonly string[] listOfGenres = new[]
    // {
    //     "Jazz", "Rock", "Hip-Hop", "RnB", "Afro-Beat", "Jazz Rap", "Blues", "Folk", "Country", "House"
    // };

    private readonly ILogger<Genre> _logger;
    private readonly Engine engine = new Engine();
    public GenreController(ILogger<Genre> logger)
    {
        _logger = logger;
    }

    [HttpGet("/genre")]
    public IActionResult Get()
    {
        _logger.LogInformation("Generating genre's...");

        var document= engine.configureEngine("https://www.musicgenreslist.com:443");
        var listOfGenres = engine.QueryData(document);

        return Ok(listOfGenres);
    }
}

