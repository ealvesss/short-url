using System;

namespace HeyUrl.Domain.Entities
{
    public class Platform : EntityBase
    {
        public string Description { get; set; }

        public Browser Browser { get; set; }

        public Guid ClickId { get; set; }

        public Click Click { get; set; }

    }
}
