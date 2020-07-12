using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Soulgram.Api.Filters;
using Soulgram.Common;
using Soulgram.Swagger;
using Soulgram.UserInfo;
using FluentValidation.AspNetCore;
using Soulgram.Api.Middelwares;
using Soulgram.DB;

namespace Soulgram.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureJsonSerialization();

            services.AddNeo4JDriver(_configuration);
            services.AddUserInfoService();

            services
                .AddHttpContextAccessor()
                .AddResponseCompression();

            services
                .AddControllers(o => o.Filters.Add<ValidationFilter>())
                .AddNewtonsoftJson(x => Serialization.UpdateJsonSettings(x.SerializerSettings))
                .AddFluentValidation();

            services
              .AddHsts(options =>
              {
                  options.Preload = true;
                  options.IncludeSubDomains = true;
              });

            services.AddSwagger(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
              .UseHttpsRedirection()
              .UseSwagger(_configuration)
              .UseRouting()
              .UseResponseCompression()
              .UseEndpoints(x => x.MapControllers());
        }

        private void ConfigureJsonSerialization()
        {
            JsonConvert.DefaultSettings = () => Serialization.JsonSerializerSettings;
        }
    }
}
