using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrl_Challenge.Application.Dtos;
using HeyUrl_Challenge.Application.Interfaces;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using HeyUrl_Challenge.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
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
        private readonly IClickApplication _clickApplication;

        public UrlsController(ILogger<UrlsController> logger, 
            IBrowserDetector browserDetector, 
            IUrlShortHelper helper, 
            IUrlApplication UrlApplication,
            IClickApplication ClickApplication)
        {
            this.browserDetector = browserDetector;
            _logger = logger;
            _urlHelper = helper;
            _urlApplication = UrlApplication;
            _clickApplication = ClickApplication;
        }

        public async Task<IActionResult> Index()
        {
            var urlBase = $"{this.Request.Scheme}/{this.Request.Host}{this.Request.Path}";
            var model = new HomeViewModel();

            model.Urls = await _urlApplication.GetAll(urlBase);
            return View(model);
        }

        [Route("/{url}")]
        public async Task<IActionResult> Visit(string url) {

            var result = await _clickApplication.InsertClick(url);

            return new OkObjectResult($"{result.Clicks}, {this.browserDetector.Browser.OS}, {this.browserDetector.Browser.Name}");
        } 

        [Route("urls/{url}")]
        public IActionResult Show(string url) => View(new ShowViewModel
        {
            Url = new UrlRequestDto {ShortUrl = url, Clicks = getrandom.Next(1, 10)},
            DailyClicks = new Dictionary<string, int>
            {
                {"1", 13},
                {"2", 2},
                {"3", 1},
                {"4", 7},
                {"5", 20},
                {"6", 18},
                {"7", 10},
                {"8", 20},
                {"9", 15},
                {"10", 5}
            },
            BrowseClicks = new Dictionary<string, int>
            {
                { "IE", 13 },
                { "Firefox", 22 },
                { "Chrome", 17 },
                { "Safari", 7 },
            },
            PlatformClicks = new Dictionary<string, int>
            {
                { "Windows", 13 },
                { "macOS", 22 },
                { "Ubuntu", 17 },
                { "Other", 7 },
            }
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(string currentUrl)
        {
            if (String.IsNullOrEmpty(currentUrl))
            {
                TempData["Notice"] = "You should fill Url Field";
                return RedirectToAction(nameof(Index));
            }
            
            currentUrl.Trim();
            
            if (!_urlHelper.IsValidUrl(currentUrl))
            {
                TempData["Notice"] = "Invalid Url!";
                return RedirectToAction(nameof(Index));
            }

            _urlApplication.Create(new UrlRequestDto() { OriginalUrl = currentUrl });

            return RedirectToAction(nameof(Index));

        }
    }
}