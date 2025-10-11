using Evaluacion.Application.Repositories;
using Evaluacion.Infrastructure.Persistence;
using Evaluacion.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                    this IServiceCollection services,
                    IConfiguration configuration)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            string connStr = configuration.GetConnectionString("OracleDb");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(connStr)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
