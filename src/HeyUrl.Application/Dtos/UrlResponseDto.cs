using System;
using System.Collections.Generic;

namespace HeyUrl.Application.Dtos
{
    public class UrlResponseDto
    {
        public Guid Id { get; set; }

        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public DateTime CreatedAt { get; private set; }

        public string CompleteUrl { get; set; }

        public IList<ClickReponseDto> Click { get; set; }

        public int Clicks { get; set; }

        public List<UrlDailyClicksDto> DailyClicks { get; set; }

        public List<UrlBrowserClicksDto> BrowserClicks { get; set; }

        public List<UrlPlatformClicksDto> PlatformClicks { get; set; }

        public UrlResponseDto()
        { }
    }
}
