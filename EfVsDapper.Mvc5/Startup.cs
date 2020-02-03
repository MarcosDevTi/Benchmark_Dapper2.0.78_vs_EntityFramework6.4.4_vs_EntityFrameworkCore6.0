using EfVsDapper.Mvc5;
using EfVsDapper.Mvc5.App_Start;
using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapperNetFramework.Context;
using EntityFrameworkVsCoreDapperNetFramework.Contracts;
using EntityFrameworkVsCoreDapperNetFramework.Helpers;
using EntityFrameworkVsCoreDapperNetFramework.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(Startup), "Configuration")]
namespace EfVsDapper.Mvc5
{
    public class Startup
    {
        public static void Configuration()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services);
            DependencyResolver.SetResolver(resolver);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DotNetCoreContext>(_ => _.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
                           Initial Catalog=CamparationEntityDapper; Integrated Security=True"));
            services.AddTransient<DapperContext>();
            services.AddScoped<Ef6Context>();

            services.AddTransient<IDapperService, DapperService>();
            services.AddTransient<IEfCoreService, EfCoreService>();
            services.AddTransient<IEf6Service, Ef6Service>();
            services.AddTransient<ConsoleHelper>();
            services.AddSingleton<ResultService>();
            services.AddSingleton<MessageService>();

            services.AddTransient(typeof(Controllers.ComplexController));
            services.AddTransient(typeof(Controllers.SinglesController));
        }

    }
}