using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Evaluacion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // 🔹 Registrar automáticamente todos los handlers (Commands & Queries)
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // 🔹 (Opcional) Registrar behaviors del pipeline
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            // 🔹 (Opcional) Registrar validadores o cualquier otro servicio de Application
            // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
