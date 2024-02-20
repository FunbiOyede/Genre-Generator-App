using Microsoft.AspNetCore.Mvc;

namespace Lofi.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
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

    [HttpGet(Name = "Get Genre")]
    public IActionResult Get()
    {
        _logger.LogInformation("Generating genre's...");

        var document= engine.configureEngine("https://www.musicgenreslist.com/");
        var listOfGenres = engine.QueryData(document);

        return Ok(listOfGenres);
    }
}

