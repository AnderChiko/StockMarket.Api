
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockMarket.Core.Logging;
using StockMarket.Core.Modules;
using StockMarket.Core.Services;
using StockMarket.Interfaces;
using StockMarket.Interfaces.Logging;
using StockMarket.Interfaces.Services;
using StockMarket.Models.Constants;
using StockMarket.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Core
{

    public static class IoC
    {
        /// <summary>
        /// Method to register the Core dependencies.
        /// 
        /// Transient: A new instance of the type is used every time the type is requested.
        /// 
        /// Scoped: A new instance of the type is created the first time it’s requested within
        ///			a given HTTP request, and then re - used for all subsequent types resolved
        ///			during that HTTP request.
        ///			
        /// Singleton: A single instance of the type is created once, and used by all subsequent
        ///			requests for that type.
        ///			
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IAlphaVantageAdpter, AlphaVantageAdpter>();
            services.AddScoped<IAlphaVantageManager, AlphaVantageManager>();
            services.AddScoped(typeof(ILoggingManager<>), typeof(LoggingManager<>));
            return services;
        }

        public static IServiceCollection AddCoreConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AlphaVantageOptions>(configuration.GetSection(ConfigSections.AlphaVantageOptions));
           
            return services;
        }

    }
}
