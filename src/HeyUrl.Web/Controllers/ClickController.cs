using HeyUrl.Application.Dtos;
using HeyUrl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shyjus.BrowserDetection;
using System;
using System.Threading.Tasks;

namespace HeyUrl.Controllers
{
    [Route("click")]
    public class ClickController : Controller
    {
        private readonly IClickApplication _clickApplication;
        private readonly IBrowserDetector _browserDetector;

        public ClickController(IBrowserDetector browser,
            IClickApplication urlApp)
        {
            _browserDetector = browser;
            _clickApplication = urlApp;
        }

        [Route("{ShortUrl}")]
        public async Task<IActionResult> Post(Guid urlId, string ShortUrl)
        {
            var clickDto = new ClickRequestDto()
            {
                UrlId = urlId,
                ShortUrl = ShortUrl,
                Platform = new PlatformDto()
                {
                    Description = this._browserDetector.Browser.OS,
                    Browser = new BrowserDto()
                    {
                        Description = this._browserDetector.Browser.Name
                    }
                }
            };
            
            var result = await _clickApplication.Create(clickDto);

            return new OkObjectResult($"{result.Click.Count}, {this._browserDetector.Browser.OS}, {this._browserDetector.Browser.Name}");
        }
    }
}
