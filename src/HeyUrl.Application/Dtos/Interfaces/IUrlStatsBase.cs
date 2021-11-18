namespace HeyUrl.Application.Dtos.Interfaces
{
    public interface IUrlStatsBase
    {
        string Stat { get; set; }

        int Clicks { get; set; }
    }
}
