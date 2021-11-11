using HeyUrl.Domain.Helper.Interface;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace HeyUrl.CrossCutting.Helper
{
    public class UrlShortHelper : IUrlShortHelper
    {
        public string ShortUrl(int id) => WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id)).Substring(0, 5).ToUpper();

        public bool IsValidUrl(string currentUrl) {
            Uri uriResult;
            return  Uri.TryCreate(currentUrl, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        
    }
}
