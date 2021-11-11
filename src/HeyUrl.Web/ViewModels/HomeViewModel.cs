using HeyUrl_Challenge.Application.Dtos;
using System.Collections.Generic;

namespace HeyUrl_Challenge.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<UrlDto> Urls { get; set; }
        public UrlDto NewUrl { get; set; }
    }
}
