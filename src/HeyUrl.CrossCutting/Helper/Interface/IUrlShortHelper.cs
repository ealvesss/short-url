namespace HeyUrl.Domain.Helper.Interface
{
    public interface IUrlShortHelper
    {
        string ShortUrl(int id);
        bool IsValidUrl(string currentUrl);
    }
}
