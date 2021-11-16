using HeyUrl_Challenge.Domain.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace HeyUrl.Helper
{
    public class UrlShortHelper : IUrlShortHelper
    {
        public string ShortUrl(Int64 id) => WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id)).Substring(0, 5).ToUpper();

        public bool IsValidUrl(string currentUrl) {
            Uri uriResult;
            return  Uri.TryCreate(currentUrl, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
