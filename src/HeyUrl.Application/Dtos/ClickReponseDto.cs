using System;

namespace HeyUrl_Challenge.Application.Dtos
{
    public class ClickReponseDto
    {

        public DateTime ClickedAt { get; set; }
        public int Clicks { get; set; }

        public ClickReponseDto()
        {}
    }
}
