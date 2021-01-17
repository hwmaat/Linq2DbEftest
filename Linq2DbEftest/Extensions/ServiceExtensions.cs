using KlantPortaalApi.Services;
using Linq2DbEftest.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linq2DbEftest.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Token-Expired")
                    );
            });

        }

        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IClientsService, ClientsService>();
        }
    }
}
