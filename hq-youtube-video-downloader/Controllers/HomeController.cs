using hq_youtube_video_downloader.Models;
using hq_youtube_video_downloader.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YoutubeExplode;

namespace hq_youtube_video_downloader.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexViewModel model)
        {
            var client = new YoutubeClient();

            // You can specify both video ID or URL
            var video = await client.Videos.GetAsync(model.VideoUrl);

            var title = video.Title;
            var author = video.Author.ChannelTitle;
            var duration = video.Duration; // hh:mm:ss

            return View(
                new HomeIndexViewModel()
                {
                    VideoUrl = model.VideoUrl,
                    Author = author,
                    Duration = duration.Value,
                    Title = title
                });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}