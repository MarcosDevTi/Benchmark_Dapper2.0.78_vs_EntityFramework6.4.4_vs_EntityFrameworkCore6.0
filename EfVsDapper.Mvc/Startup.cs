using EfVsDapper.Mvc.Queries;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Helpers;
using EntityFrameworkVsCoreDapper.Results;
using EntityFrameworkVsCoreDapper.Tests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EfVsDapper.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DotNetCoreContext>(_ =>
                _.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DapperContext>();
            services.AddScoped<Ef6Context>();
            services.AddScoped<IDapperService, DapperService>();
            services.AddScoped<IEfCoreService, EfCoreService>();
            services.AddScoped<IEf6Service, Ef6Service>();
            services.AddScoped<IAdoService, AdoService>();
            services.AddScoped<ConsoleHelper>();
            services.AddScoped<ResultService>();
            services.AddScoped<CustomersWhereAddressCountryAndProductsCount>();
            services.AddSingleton<MessageService>();
            services.AddSingleton<ReflectionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Singles}/{action=SelectSingles}/{id?}");
            });
        }
    }
}
