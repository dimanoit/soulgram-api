using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soulgram.UserInfoDB.Entities;
using Soulgram.UserInfoDB.Options;
using Soulgram.UserInfoDB.Repositories;
using Soulgram.UserInfoDB.Repositories.QueriesBuilder;

namespace Soulgram.UserInfoDB
{
    public static class Bootstrap
    {
        public static IServiceCollection AddUserInfoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("UserInfoDb");
            services.Configure<DbOptions>(options)
                .AddScoped<IDbAccessor, DbAccessor>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IQueriesBuilder<User>, PgQueriesBuilder<User>>()
                .AddScoped<IQueriesBuilder<Hobby>, PgQueriesBuilder<Hobby>>();

            return services;
        }
    }
}
