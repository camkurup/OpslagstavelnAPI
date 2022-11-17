using Microsoft.AspNetCore.Mvc;
using OpslagstavelnAPI;
using System.Drawing;

namespace OpslagstavlenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Image img1 = new Bitmap("C:\\Users\\CKU\\Documents\\Skole\\H4\\Sikkerhed og Kryptering\\OpslagstavelnAPI\\OpslagstavelnAPI\\img\\Syngonium0.jpg");
            Image img2 = new Bitmap("C:\\Users\\CKU\\Documents\\Skole\\H4\\Sikkerhed og Kryptering\\OpslagstavelnAPI\\OpslagstavelnAPI\\img\\Syngonium1.jpg");
            Image img3 = new Bitmap("C:\\Users\\CKU\\Documents\\Skole\\H4\\Sikkerhed og Kryptering\\OpslagstavelnAPI\\OpslagstavelnAPI\\img\\Syngonium2.jpg");
            Image img4 = new Bitmap("C:\\Users\\CKU\\Documents\\Skole\\H4\\Sikkerhed og Kryptering\\OpslagstavelnAPI\\OpslagstavelnAPI\\img\\Syngonium3.jpg");
            using (MemoryStream ms = new MemoryStream())
            {
                img1.Save(ms, img1.RawFormat);
                string img1Base64String = Convert.ToBase64String(ms.ToArray());
                img1.Save(ms, img2.RawFormat);
                string img2Base64String = Convert.ToBase64String(ms.ToArray());
                img1.Save(ms, img3.RawFormat);
                string img3Base64String = Convert.ToBase64String(ms.ToArray());
                Summaries[0] = img1Base64String;
                Summaries[1] = img2Base64String;
                Summaries[2] = img3Base64String;
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
}