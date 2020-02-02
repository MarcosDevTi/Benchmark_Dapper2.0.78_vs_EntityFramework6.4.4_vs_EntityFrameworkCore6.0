using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.ConsoleTest.Tests;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Results;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DotNetCoreContext>(_ => _.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
                           Initial Catalog=CamparationEntityDapper; Integrated Security=True"), ServiceLifetime.Transient);
            services.AddScoped<DapperContext>();
            services.AddScoped<Ef6Context>();
            services.AddTransient<IInserts, Inserts>();
            services.AddTransient<ISelects, Selects>();
            services.AddTransient<IDapperService, DapperService>();
            services.AddTransient<IEfCoreService, EfCoreService>();
            services.AddTransient<IEf6Service, Ef6Service>();
            services.AddTransient<ConsoleHelper>();
            services.AddTransient<ResultService>();
            services.AddSingleton<MessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
