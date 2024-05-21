using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using Xunit;

namespace MarsRoverPhotos.Services.Tests
{
  public class BeholdNasaTests
  {
    [Fact]
    public async Task GetMarsRoverPhotosAsync_ReturnsPhotosArray()
    {
      // Arrange
      var apiUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=";
      var apiKey = "DEMO_KEY";
      Environment.SetEnvironmentVariable("API_URL", apiUrl);
      Environment.SetEnvironmentVariable("API_KEY", apiKey);

      var date = new DateTime(2023, 1, 1);
      var photosJson = new JObject
      {
        ["photos"] = new JArray
    {
        new JObject { ["id"] = 1, ["img_src"] = "http://example.com/photo1.jpg" },
        new JObject { ["id"] = 2, ["img_src"] = "http://example.com/photo2.jpg" }
    }
      }.ToString();

      var handlerMock = new Mock<HttpMessageHandler>();
      handlerMock.Protected()
         .Setup<Task<HttpResponseMessage>>(
      "SendAsync",
      ItExpr.IsAny<HttpRequestMessage>(),
      ItExpr.IsAny<CancellationToken>())
   .ReturnsAsync(new HttpResponseMessage()
   {
     StatusCode = HttpStatusCode.OK,
     Content = new StringContent(photosJson),
   })
   .Verifiable();

      var httpClient = new HttpClient(handlerMock.Object);

      var beholdNasa = new BeholdNasa(httpClient);

      // Act
      var result = await beholdNasa.GetMarsRoverPhotosAsync(date);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(2, result.Count);
      Assert.Equal(1, result[0]["id"]);
      Assert.Equal("http://example.com/photo1.jpg", result[0]["img_src"]);
      Assert.Equal(2, result[1]["id"]);
      Assert.Equal("http://example.com/photo2.jpg", result[1]["img_src"]);
    }
  }
}
