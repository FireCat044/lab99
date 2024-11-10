using Microsoft.AspNetCore.Mvc;
using lab99.Models;

namespace lab99.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly WeatherService _weatherService;

        public WeatherViewComponent(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string region)
        {
            WeatherInfo weatherInfo = await _weatherService.GetWeatherAsync(region);
            return View(weatherInfo);
        }
    }
}
