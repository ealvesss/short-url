using HeyUrl.Application.Dtos;
using System;
using System.Collections.Generic;

namespace HeyUrl.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<UrlResponseDto> Urls { get; set; }
        public UrlRequestDto NewUrl { get; set; }
    }
}
