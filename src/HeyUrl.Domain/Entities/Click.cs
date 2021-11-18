using System;

namespace HeyUrl.Domain.Entities
{
    public class Click : EntityBase
    {
        public DateTime ClickedAt { get; set; }

        public Guid UrlId { get; set; }

        public Url Url { get; set; }

        public Platform Platform { get; set; }

        public Click()
        {
        }
    }

}
