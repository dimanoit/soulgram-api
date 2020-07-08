using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Soulgram.Validation
{
    public static class ValidationBootstrapExtensions
    {
        public static IServiceCollection AddValidator<T, TV>(this IServiceCollection services) where TV : AbstractValidator<T>
        {
            return services.AddTransient<IValidator<T>, TV>();
        }
    }
}
