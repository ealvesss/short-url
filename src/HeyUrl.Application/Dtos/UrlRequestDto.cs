using System;
using System.Collections.Generic;

namespace HeyUrl.Application.Dtos
{
    public class UrlRequestDto
    {
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; private set; }
        public int Clicks { get; set; }
        public ClickRequestDto Click { get; set; }

        public UrlRequestDto()
        {
            CreatedAt = DateTime.Now;
            ShortUrl = "";
        }

    }
}
