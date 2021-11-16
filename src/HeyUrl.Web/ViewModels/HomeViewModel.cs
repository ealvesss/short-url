using HeyUrl_Challenge.Application.Dtos;
using System.Collections.Generic;

namespace HeyUrl_Challenge.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<UrlResponseDto> Urls { get; set; }
        public UrlRequestDto NewUrl { get; set; }
    }
}
