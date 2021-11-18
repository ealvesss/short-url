using System;

namespace HeyUrl.Application.Dtos
{
    public class ClickReponseDto
    {

        public DateTime ClickedAt { get; set; }
        public int Clicks { get; set; }

        public ClickReponseDto()
        { }
    }
}
