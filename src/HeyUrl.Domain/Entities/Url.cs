using System;
using System.Collections.Generic;

namespace HeyUrl.Domain.Entities
{
    public class Url : EntityBase
    {
        public string ShortUrl { get; set; }

        public string OriginalUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public IList<Click> Click { get; set; }

    }
}
