using System;

namespace HeyUrl.Domain.Helper.Interface
{
    public interface IUrlShortHelper
    {
        string ShortUrl(Int64 id);
        bool IsValidUrl(string currentUrl);
    }
}
