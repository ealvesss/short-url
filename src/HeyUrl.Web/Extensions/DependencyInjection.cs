﻿using HeyUrl.Application;
using HeyUrl.Application.Interfaces;
using HeyUrl.Domain;
using HeyUrl.Domain.Services;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl.Helper;
using HeyUrl.Infra.Context;
using HeyUrl.Infra.Helper;
using HeyUrl.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HeyUrl.Extensions
{
    public static class DependencyInjection
    {

        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(
                options =>
                options.UseNpgsql("Host=localhost;Database=ShortUrl;Username=postgres;Password=mydb1234")
                       .EnableSensitiveDataLogging(true)
             );

            services.AddScoped<IUrlShortHelper, UrlShortHelper>();
            services.AddScoped<IUrlApplication, UrlApplication>();
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IUrlRepository, UrlRepository>();
            services.AddScoped<IClickRepository, ClickRepository>();
            services.AddScoped<IClickApplication, ClickApplication>();
            services.AddScoped<IClickService, ClickService>();
            services.AddScoped<IDbHelper, DbHelper>();
        }
    }
}
