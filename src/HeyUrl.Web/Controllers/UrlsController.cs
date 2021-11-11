using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrl.Domain.Helper.Interface;
using HeyUrl_Challenge.Application.Dtos;
using HeyUrl_Challenge.Application.Interfaces;
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

        public UrlsController(ILogger<UrlsController> logger, IBrowserDetector browserDetector, IUrlShortHelper helper, IUrlApplication application)
        {
            this.browserDetector = browserDetector;
            _logger = logger;
            _urlHelper = helper;
            _urlApplication = application;
        }

        public async Task<IActionResult> Index()
        {
            var urlBase = $"{this.Request.Scheme}/{this.Request.Host}{this.Request.Path}";
            var model = new HomeViewModel();

            model.Urls = await _urlApplication.GetAll(urlBase);
            return View(model);
        }

        [Route("/{url}")]
        public IActionResult Visit(string url) { 


            return new OkObjectResult($"{url}, {this.browserDetector.Browser.OS}, {this.browserDetector.Browser.Name}");
        } 

        [Route("urls/{url}")]
        public IActionResult Show(string url) => View(new ShowViewModel
        {
            Url = new UrlDto {ShortUrl = url, Count = getrandom.Next(1, 10)},
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

            _urlApplication.Create(new UrlDto() { OriginalUrl = currentUrl });

            return RedirectToAction(nameof(Index));

        }
    }
}