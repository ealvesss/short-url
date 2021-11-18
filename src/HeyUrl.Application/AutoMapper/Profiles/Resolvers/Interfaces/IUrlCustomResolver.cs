using AutoMapper;

namespace HeyUrl.Application.AutoMapper.Profiles.Resolvers.Interfaces
{
    public interface IUrlCustomResolver<in TSource, in TDestination, TDestMember>
    {
        TDestMember ConstructFullUrl(TSource source, TDestination destination, TDestMember destMember, ResolutionContext context);
    }
}
