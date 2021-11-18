using AutoMapper;
using HeyUrl.Application.AutoMapper.Profiles.Resolvers.Interfaces;
using HeyUrl.Application.Dtos;
using HeyUrl.Domain.Entities;

namespace HeyUrl.Application.AutoMapper.Profiles.Resolvers
{
    public class UrlCustomResolver : IUrlCustomResolver<Url, UrlResponseDto, string>
    {
        const string BASE_URL = "baseUrl";

        public string ConstructFullUrl(Url source, UrlResponseDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                return string.Format("{0}{1}", context.Items[BASE_URL], source.ShortUrl);
            }
            catch (System.Exception)
            {

                return "";
            }           
        }
    }
}
