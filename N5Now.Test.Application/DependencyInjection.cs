using Microsoft.Extensions.DependencyInjection;
using N5Now.Test.Application.Services;
using N5Now.Test.Domain.Interfaces.Services;
using Nest;
using Serilog;

namespace N5Now.Test.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<ILoggerService, LoggerService>();
            services.AddSingleton<IKafkaProducerService, KafkaProducerService>();
            services.AddSingleton<IElasticSearchService, ElasticSearchService>();
            return services;
        }
    }
}
