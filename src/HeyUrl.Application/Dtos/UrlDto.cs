using System;

namespace HeyUrl_Challenge.Application.Dtos
{
    public class UrlDto
    {
        public string OriginalUrl { get; set; }
        public int Count { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string Stats { get; set; }

        public UrlDto()
        {
            CreatedAt = DateTime.Now;
            ShortUrl = "";
        }

    }
}
