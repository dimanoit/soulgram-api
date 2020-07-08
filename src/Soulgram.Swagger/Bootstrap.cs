using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Soulgram.Swagger
{
    public static class Bootstrap
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerOptions = configuration
                .GetSection("Swagger")
                .Get<SwaggerOptions>();

            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerOptions.ApiDetails.Version,
                    new OpenApiInfo
                    {
                        Title = swaggerOptions.ApiDetails.Title,
                        Version = swaggerOptions.ApiDetails.Version,
                        Description = swaggerOptions.ApiDetails.Description
                    });

                var filePath = Path.Combine(AppContext.BaseDirectory, swaggerOptions.FileName);
                if (File.Exists(filePath))
                {
                    options.IncludeXmlComments(filePath);
                }

                options.DescribeAllParametersInCamelCase();
            })
                .AddSwaggerGenNewtonsoftSupport();
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerOptions = configuration.GetSection("Swagger").Get<SwaggerOptions>();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint($"/{swaggerOptions.Route}/v1/swagger.json", swaggerOptions.ApiDetails.Title);
            });

            return app;
        }
    }
}
