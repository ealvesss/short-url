using HeyUrl_Challenge.Application.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace HeyUrl_Challenge.Extensions
{
    public static class AutoMapperProfile
    {
        public static void InjectProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(options => options.AddProfile<UrlProfile>());
            services.AddAutoMapper(options => options.AddProfile<ClickProfile>());
        }
    }
}
