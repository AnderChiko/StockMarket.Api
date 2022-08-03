using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using StockMarket.Api.Handler;
using StockMarket.Core.Services;
using StockMarket.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockMarket.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddServices();
            services.AddOptions();
            services.AddOptions(Configuration);
            services.AddControllers();

            services.AddCors();

            services.AddMemoryCache();

            //to do : to test rate limit on class out going calls
            //services.AddHttpClient<IAlphaVantageManager, AlphaVantageManager>()
            //       .AddHttpMessageHandler(() =>
            //               new RateLimitHttpMessageHandler(
            //                    limitCount: 5,
            //                    limitTime: TimeSpan.FromMinutes(1)))
            //            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

            ConfigureCorsServices(services);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // https://stackoverflow.com/questions/2441290/javascriptserializer-json-serialization-of-enum-as-string/2870420#2870420
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StockMarket.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockMarket.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Configure Cors
        /// See: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureCorsServices(IServiceCollection services)
        {
            var origins = Configuration.GetSection("AllowedOrigins").Value.Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                                  policy =>
                                  {
                                      policy.WithOrigins(origins);
                                  });
            });
        }
    }
}
