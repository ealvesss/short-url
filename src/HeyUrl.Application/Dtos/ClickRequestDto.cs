using System;

namespace HeyUrl_Challenge.Application.Dtos
{
    public class ClickRequestDto
    {
        public DateTime ClickedAt { get; set; }
        public int Clicks { get; set; } 

        public ClickRequestDto()
        {
            ClickedAt = DateTime.Now;
        }
    }
}
