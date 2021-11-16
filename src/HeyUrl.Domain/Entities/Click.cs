using System;
using System.ComponentModel.DataAnnotations;

namespace HeyUrl.Domain.Entities
{
    public class Click : EntityBase
    {
		[DataType(DataType.Date)]
		public DateTime ClickedAt { get; set; }

		public Int64 Clicks { get; set; } = 0;	

		public Guid UrlId { get; set; }

		public Url Url { get; set; }

        public Click()
        {
        }
	}

}
