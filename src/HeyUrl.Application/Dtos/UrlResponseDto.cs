using System;

namespace HeyUrl_Challenge.Application.Dtos
{
    public class UrlResponseDto
    {
        public string OriginalUrl { get; set; }
        public int Clicks { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string Stats { get; set; }

        public ClickRequestDto Click { get; set; }

        public UrlResponseDto()
        {
            Click = new ClickRequestDto();
        }
    }
}
