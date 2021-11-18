using HeyUrl.Application.Dtos.Interfaces;

namespace HeyUrl.Application.Dtos
{
    public abstract class UrlStatsBase : IUrlStatsBase
    {
        public virtual string Stat { get; set; }
        public virtual int Clicks { get; set; }
    }
}
