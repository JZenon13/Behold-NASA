using Newtonsoft.Json.Linq;

namespace MarsRoverPhotos.Services
{
  public class BeholdNasa
  {
    private readonly string? _apiUrl;
    private readonly string? _apiKey;
    public HttpClient httpClient;
    public BeholdNasa(HttpClient httpClient)
    {
      _apiUrl = Environment.GetEnvironmentVariable("API_URL");
      _apiKey = Environment.GetEnvironmentVariable("API_KEY");
      this.httpClient = httpClient;

      if (string.IsNullOrEmpty(_apiUrl))
      {
        throw new InvalidOperationException("API_URL environment variable is not set.");
      }
      if (string.IsNullOrEmpty(_apiKey))
      {
        throw new InvalidOperationException("API_KEY environment variable is not set.");
      }
    }

    public async Task<JArray> GetMarsRoverPhotosAsync(DateTime date)
    {
      string dateString = date.ToString("yyyy-MM-dd");
      string url = $"{_apiUrl}{dateString}&api_key={_apiKey}";

      var response = await httpClient.GetStringAsync(url);
      var data = JObject.Parse(response);

      return (JArray)data["photos"];
    }
  }
}
