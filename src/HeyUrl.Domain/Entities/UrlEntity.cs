using System;
using System.ComponentModel.DataAnnotations;

namespace HeyUrl.Domain.Entities
{
    public class UrlEntity : EntityBase
    {
        public int ShortUrlId { get; set; }

        [Required]
        public string ShortUrl { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        public ClickEntity Click { get; set; }

    }
}
