using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Integrations
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _conn;

        public DbConnectionFactory(IConfiguration c) 
        {
            _conn = c.GetConnectionString("DefaultConnection");
        }

        public string GetConnStr() => _conn;
    }

    public static class InfrastructureDependenciesInjection
    {
        public static void AddInfrastructures(this IServiceCollection service)
        {
            service.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            service.AddScoped<IDb, Db>();
            service.AddTransient<IPgCmd, PgCmd>();
        }
    }
}
