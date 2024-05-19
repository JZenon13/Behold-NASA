using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;




namespace MarsRoverPhotos.Services
{
  public class BeholdNasa
  {
    private readonly string? _baseUrl;
    private readonly string? _apiKey;
    public HttpClient httpClient;
    public BeholdNasa(HttpClient httpClient)
    {
      _baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
      _apiKey = Environment.GetEnvironmentVariable("API_KEY");
      this.httpClient = httpClient;

      if (string.IsNullOrEmpty(_baseUrl))
      {
        throw new InvalidOperationException("BASE_URL environment variable is not set.");
      }
      if (string.IsNullOrEmpty(_apiKey))
      {
        throw new InvalidOperationException("API_KEY environment variable is not set.");
      }
    }

    public async Task<JArray> GetMarsRoverPhotosAsync(DateTime date)
    {
      string dateString = date.ToString("yyyy-MM-dd");
      string url = $"{_baseUrl}{dateString}&api_key={_apiKey}";

      var response = await httpClient.GetStringAsync(url);
      var data = JObject.Parse(response);

      return (JArray)data["photos"];
    }
  }
}
