using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.ConsoleTest.Tests;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<DapperContext>();
            services.AddScoped<Ef6Context>();
            services.AddTransient<IInserts, Inserts>();
            services.AddTransient<ISelects, Selects>();
            services.AddTransient<IDapperService, DapperService>();
            services.AddTransient<IEfCoreService, EfCoreService>();
            services.AddTransient<IEf6Service, Ef6Service>();
            services.AddTransient<ConsoleHelper>();
            services.AddSingleton<ResultService>();
        }
    }
}
