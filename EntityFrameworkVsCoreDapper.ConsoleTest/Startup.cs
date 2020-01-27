using EntityFrameworkVsCoreDapper.ConsoleTest.Tests;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class Startup
    {
        public ServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection();
            Register(services);
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public void Register(IServiceCollection services)
        {
            services.AddDbContext<DotNetCoreContext>(_ => _.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
                           Initial Catalog=CamparationEntityDapper; Integrated Security=True"));
            services.AddScoped<DapperContext>();
            services.AddScoped<Ef6Context>();
            services.AddTransient<IInserts, Inserts>();
            services.AddTransient<ISelects, Selects>();
            services.AddTransient<IDapperTests, DapperTests>();
            services.AddTransient<IEfCoreTests, EfCoreTests>();
            services.AddTransient<IEf6Tests, Ef6Tests>();
        }
    }
}
