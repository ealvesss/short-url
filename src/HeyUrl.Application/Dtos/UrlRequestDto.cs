using System;

namespace HeyUrl_Challenge.Application.Dtos
{
    public class UrlRequestDto
    {
        public string OriginalUrl { get; set; }
        public int Clicks { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string Stats { get; set; }

        public ClickRequestDto Click { get; set; }

        public UrlRequestDto()
        {
            CreatedAt = DateTime.Now;
            ShortUrl = "";
        }

    }
}
