using System;
using System.ComponentModel.DataAnnotations;

namespace HeyUrl.Domain.Entities
{
    public class Url : EntityBase
    {
        [Required]
        public string ShortUrl { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        public Click Click { get; set; }
    }
}
