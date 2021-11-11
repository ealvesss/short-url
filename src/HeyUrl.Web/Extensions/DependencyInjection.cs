using HeyUrl.CrossCutting.Helper;
using HeyUrl.Domain;
using HeyUrl.Domain.Helper;
using HeyUrl.Domain.Helper.Interface;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl.Infra.Context;
using HeyUrl_Challenge.Application.AutoMapper.Profiles;
using HeyUrl_Challenge.Application.Interfaces;
using HeyUrl_Challenge.Application.Services;
using HeyUrl_Challenge.Domain.Services;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using HeyUrl_Challenge.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HeyUrl_Challenge.Extensions
{
    public static class DependencyInjection
    {

        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(
                options =>
                options.UseNpgsql("Host=localhost;Database=ShortUrl;Username=postgres;Password=mydb1234")
             ) ;

            services.AddScoped<IUrlShortHelper, UrlShortHelper>();
            services.AddScoped<IUrlApplication, UrlApplication>();
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IUrlRepository, UrlRepository>();
        }
    }
}
