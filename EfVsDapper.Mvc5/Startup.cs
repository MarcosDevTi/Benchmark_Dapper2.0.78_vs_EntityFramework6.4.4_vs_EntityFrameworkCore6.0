using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfVsDapper.Mvc5
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
            //services.AddDbContext<DotNetCoreContext>(_ => _.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
            //               Initial Catalog=CamparationEntityDapper; Integrated Security=True"));
            //services.AddTransient<DapperContext>();
            //services.AddScoped<Ef6Context>();
           
            //services.AddTransient<IDapperService, DapperService>();
            //services.AddTransient<IEfCoreService, EfCoreService>();
            //services.AddTransient<IEf6Service, Ef6Service>();
            //services.AddTransient<ConsoleHelper>();
            //services.AddSingleton<ResultService>();
        }
    }
}