using System;
using System.ComponentModel.DataAnnotations;

namespace HeyUrl.Domain.Entities
{
    public class ClickEntity : EntityBase
    {
		
		[Required]
		public string ShortUrl { get; set; }
		
		[Required]
		public string Browser { get; set; }
		
		[Required]
		public string Platform { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime ClickedAt { get; set; }

	}

}
