using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ApplicationDbContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var appContext = _context.Clients.Include(h => h.Company);

        var listCli = appContext.ToList();

        foreach (var cli in appContext)
        {
            Console.WriteLine(cli.Name + " pertenece a la empresa:  " + cli.Company.Name);
        }

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
