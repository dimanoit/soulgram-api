using Microsoft.Extensions.DependencyInjection;
using Soulgram.UserInfo.Models;
using Soulgram.UserInfo.Validation;
using Soulgram.Validation;

namespace Soulgram.UserInfo
{
    public static class Bootstrap
    {
        public static IServiceCollection AddUserInfoService(this IServiceCollection services)
        {
            return services
                .AddTransient<IUserInfoService, UserInfoService>()
                .AddValidator<UserInfoRequest, UserInfoRequestValidator>();
        }
    }
}
