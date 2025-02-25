using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using N5Now.Test.Domain.Common.Entities;
using N5Now.Test.Infrastructure.Repositories;
using N5Now.Test.Infrastructure.Data;
using N5Now.Test.Domain.Interfaces.Repositories;

namespace N5Now.Test.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrucure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.Configure<AppSettings>(op => configuration.Bind(op));
            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DbTest")));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
            return services;
        }
    }
}
