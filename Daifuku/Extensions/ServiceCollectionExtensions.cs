using Daifuku.Services;
using Microsoft.Extensions.DependencyInjection;
using Momo.Tokens;

namespace Daifuku.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add universal time service.
        /// </summary>
        /// <param name="services">A collection of services.</param>
        /// <returns>A collection of services.</returns>
        public static IServiceCollection AddUniversalTime(this IServiceCollection services)
        {
            return services.AddTransient<IUniversalTime, UniversalTime>();
        }

        /// <summary>
        /// Add universal time service.
        /// </summary>
        /// <param name="services">A collection of services.</param>
        /// <param name="timezone">A name of timezone.</param>
        /// <returns>A collection of services.</returns>
        public static IServiceCollection AddUniversalTime(this IServiceCollection services, string timezone)
        {
            return services.AddTransient<IUniversalTime>(_ => new UniversalTime(timezone));
        }

        /// <summary>
        /// Add universal time service.
        /// </summary>
        /// <param name="services">A collection of services.</param>
        /// <param name="universalTimeConfiguration">Universal time configuration.</param>
        /// <returns>A collection of services.</returns>
        public static IServiceCollection AddUniversalTime(this IServiceCollection services, IUniversalTimeConfiguration universalTimeConfiguration)
        {
            return services.AddTransient<IUniversalTime>(_ => new UniversalTime(universalTimeConfiguration));
        }
    }
}