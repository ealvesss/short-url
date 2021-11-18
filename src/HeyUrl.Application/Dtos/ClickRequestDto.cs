using System;

namespace HeyUrl.Application.Dtos
{
    public class ClickRequestDto
    {
        public Guid UrlId { get; set; }
        public DateTime ClickedAt { get; set; }
        public PlatformDto Platform {get;set;}
        public string ShortUrl { get; set;}

        public ClickRequestDto()
        {
            ClickedAt = DateTime.Now;
        }
    }
}
