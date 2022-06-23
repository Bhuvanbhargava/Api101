using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App101.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] Days = new[]
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        private static readonly string[] Messages = new[]
        {
           
            "Everything you need to learn and to achieve your vision of prosperity is at your fingertips. You just need a plan to leverage it.",
            "There simply is no substitute for having your own positive attitude.",
            "Life is full of happiness, enjoy it. Life is full of adventure, discover it.",
            "The human desire for adventure is insatiable. So it makes no sense to relegate adventure to just those two precious vacation weeks each year.",
            "Not only will random acts of kindness help other people out but they will make you feel better inside and the flame inside will get bigger as you continue to pass it on.",
            "Random acts of kindness help us realize the pleasure of giving. It's something beyond earning.",
            "Friendships are one of life's greatest gifts. They're like treasures—you never know what you're going to discover about yourself or someone else."
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Console.WriteLine(HttpContext.User);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                Day = Days[rng.Next(Days.Length)],
                TemperatureC = rng.Next(-20, 46),
                Message = Messages[rng.Next(Messages.Length)],
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
