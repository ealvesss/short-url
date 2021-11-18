using HeyUrl.Application.Dtos;
using System.Collections.Generic;

namespace hey_url_challenge_code_dotnet.ViewModels
{
    public class ShowViewModel
    {
        public UrlResponseDto Url { get; set; }
        public string OriginalUrl { get; set; }
        public string CreatedAt { get; set; }
        public List<UrlDailyClicksDto> DailyClicks { get; set; }
        public List<UrlBrowserClicksDto> BrowseClicks { get; set; }
        public List<UrlPlatformClicksDto> PlatformClicks { get; set; }
    }
}