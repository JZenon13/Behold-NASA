using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using MarsRoverPhotos.Services;

namespace MarsRoverPhotos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MarsRoverController : ControllerBase
  {
    private readonly BeholdNasa _beholdNasa;

    public MarsRoverController(BeholdNasa beholdNasa)
    {
      _beholdNasa = beholdNasa;
    }

    [HttpGet("download-images")]
    public async Task<IActionResult> DownloadImages()
    {
      string path = Path.Combine(Directory.GetCurrentDirectory(), "api", "dates.txt");

      var dates = System.IO.File.ReadAllLines(path);



      string[] dateFormats = { "MM/dd/yy", "MMMM d, yyyy", "MMM-dd-yyyy" };

      var imageUrls = new List<object>();

      foreach (var dateStr in dates)
      {
        if (DateTime.TryParseExact(dateStr,
            dateFormats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var date))
        {
          var photos = await _beholdNasa.GetMarsRoverPhotosAsync(date);
          var urlsForDate = new List<string>();
          foreach (var photo in photos)
          {
            var imgUrl = photo["img_src"].ToString();
            urlsForDate.Add(imgUrl);

            var imgData = await _beholdNasa.httpClient.GetByteArrayAsync(imgUrl);
            var fileName = Path.GetFileName(imgUrl);
            var savePath = Path.Combine("Images", fileName);

            var directoryPath = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directoryPath))
            {
              Directory.CreateDirectory(directoryPath);
            }

            await System.IO.File.WriteAllBytesAsync(savePath, imgData);
          }
          imageUrls.Add(new { date = dateStr, images = urlsForDate });
        }
        else
        {
          Console.WriteLine($"Warning: Could not parse date string '{dateStr}'");
        }
      }

      return Ok(imageUrls);
    }
  }
}
