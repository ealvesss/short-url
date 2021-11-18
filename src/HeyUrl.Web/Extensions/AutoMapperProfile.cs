using HeyUrl.Application.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace HeyUrl.Extensions
{
    public static class AutoMapperProfile
    {
        public static void InjectProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(options => options.AddProfile<UrlProfile>());
            services.AddAutoMapper(options => options.AddProfile<ClickProfile>());
            services.AddAutoMapper(options => options.AddProfile<BrowserProfile>());
            services.AddAutoMapper(options => options.AddProfile<PlatformProfile>());
        }
    }
}
