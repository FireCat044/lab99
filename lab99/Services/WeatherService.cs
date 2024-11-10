using lab99.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "da86c0d8eaa581c57fa2af8ae3e0294e";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherInfo> GetWeatherAsync(string region)
    {
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={region}&units=metric&appid={_apiKey}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var weatherData = JsonDocument.Parse(json);

        return new WeatherInfo
        {
            Description = weatherData.RootElement.GetProperty("weather")[0].GetProperty("description").GetString(),
            Temperature = weatherData.RootElement.GetProperty("main").GetProperty("temp").GetDouble(),
            Humidity = weatherData.RootElement.GetProperty("main").GetProperty("humidity").GetDouble(),
        };
    }
}