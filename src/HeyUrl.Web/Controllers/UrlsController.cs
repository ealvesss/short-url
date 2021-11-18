using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrl.Application.Dtos;
using HeyUrl.Application.Interfaces;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;
using System;
using System.Threading.Tasks;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;
        private static readonly Random getrandom = new Random();
        private readonly IBrowserDetector browserDetector;
        private readonly IUrlShortHelper _urlHelper;
        private readonly IUrlApplication _urlApplication;

        public UrlsController(ILogger<UrlsController> logger,
            IBrowserDetector browserDetector,
            IUrlShortHelper helper,
            IUrlApplication UrlApplication)
        {
            this.browserDetector = browserDetector;
            _logger = logger;
            _urlHelper = helper;
            _urlApplication = UrlApplication;
        }

        public async Task<IActionResult> Index()
        {
            var urlBase = $"{this.Request.Scheme}/{this.Request.Host}{this.Request.Path}";
            var model = new HomeViewModel();

            model.Urls = await _urlApplication.GetAll(urlBase);
            return View(model);
        }

        [Route("stats/{shortUrl}")]
        public async Task<IActionResult> Show(Guid UrlId, string shortUrl)
        {
            var urlDto = await _urlApplication.GetById(UrlId);

            var Url = new ShowViewModel()
            {
                Url = urlDto,
                DailyClicks = urlDto.DailyClicks,
                BrowseClicks = urlDto.BrowserClicks,
                PlatformClicks = urlDto.PlatformClicks,
                CreatedAt = urlDto.CreatedAt.ToString("MMM d, yyy")
            };

            return View(Url);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(string currentUrl)
        {
           TempData["Notice"] = _urlApplication.Create(new UrlRequestDto() { OriginalUrl = currentUrl });

           return RedirectToAction(nameof(Index));

        }
    }
}