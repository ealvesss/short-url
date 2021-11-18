using System;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IUrlShortHelper
    {
        string ShortUrl(Int64 id);
        bool IsValidUrl(string currentUrl);
    }
}
