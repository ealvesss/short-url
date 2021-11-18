using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public  interface IUrlShortHelper
    {
        string ShortUrl(Int64 id);
        bool IsValidUrl(string currentUrl);
    }
}
