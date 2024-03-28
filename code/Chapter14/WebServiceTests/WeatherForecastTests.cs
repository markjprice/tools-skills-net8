using Microsoft.AspNetCore.Mvc.Testing; // To use WebApplicationFactory<T>.
using System.Net.Http.Json; // To use ReadFromJsonAsync.
using WeatherService; // To use Program.

namespace WebServiceTests;

public class WeatherForecastTests : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;
  private const string relativePath = "/weatherforecast";

  public WeatherForecastTests(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async Task Get_WeatherForecasts_ReturnsSuccessStatusCode()
  {
    // Arrange
    HttpClient client = _factory.CreateClient();

    // Act
    HttpResponseMessage response = 
      await client.GetAsync(relativePath);

    // Assert
    Assert.True(response.IsSuccessStatusCode); // Status Code 200-299.
  }

  [Fact]
  public async Task Get_WeatherForecasts_ReturnsFiveForecasts()
  {
    // Arrange
    HttpClient client = _factory.CreateClient();

    // Act
    HttpResponseMessage response = await client.GetAsync(relativePath);
    WeatherForecast[]? forecasts = await response.Content
      .ReadFromJsonAsync<WeatherForecast[]>();

    // Assert
    Assert.NotNull(forecasts);
    Assert.True(forecasts.Length == 5);
  }
}
