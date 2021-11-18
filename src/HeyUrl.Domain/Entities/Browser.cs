using System;

namespace HeyUrl.Domain.Entities
{
    public class Browser : EntityBase
    {
        public string Description { get; set; }

        public Guid PlatformId { get; set; }

        public Platform Platform { get; set; }

    }
}
