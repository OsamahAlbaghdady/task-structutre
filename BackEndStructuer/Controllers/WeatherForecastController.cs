using BackEndStructuer.DATA;
using BackEndStructuer.Helpers;
using BackEndStructuer.Properties;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;

[ServiceFilter(typeof(AuthorizeActionFilter))]

public class WeatherForecastController : BaseController
{
    private readonly DataContext _context;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public WeatherForecastController(DataContext context) 
    {
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
       // create 500 error
         // throw new Exception("Test Exception");
          var thing = _context.Articles.Find(-1);
          var thingToReturn = thing.ToString();
            return Ok(thingToReturn);

    }
}