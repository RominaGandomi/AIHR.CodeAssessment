using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Workload.Business.Entities;
using Workload.Business.Services;
using Workload.Data;
using Workload.Data.Services;
using Workload.WebApi.Enums;
using Workload.WebApi.Helpers;
using Workload.WebApi.Interfaces;
using Workload.WebApi.MiddleWares;
using Workload.WebApi.Models;
using Workload.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Workload.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private ConfigManager configManager;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddControllersWithViews();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            configManager = new ConfigManager();
            Configuration.Bind(configManager);
            services.AddSingleton(configManager);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });


            if (configManager.DataBase.Type == DataBaseType.InMemory.ToString())
                services.AddDbContext<CourcesDbContext>(opt => opt.UseInMemoryDatabase(databaseName: configManager.DataBase.Name), ServiceLifetime.Scoped);
            else
                services.AddDbContext<CourcesDbContext>(opt => opt.UseSqlServer(configManager.DataBase.ConnectionString), ServiceLifetime.Scoped);


            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<WorkLoadApiService>().As<IWorkLoadApiService>().InstancePerDependency();
            builder.RegisterType<WorkLoadDataService>().As<IWorkLoadDataService>().InstancePerDependency();
            builder.RegisterType<CourceService>().As<ICourceService>().InstancePerDependency();
            builder.RegisterType<WorkLoadHistoryService>().As<IWorkLoadHistoryService>().InstancePerDependency();
            builder.RegisterType<WorkLoadHistoryCourcesService>().As<IWorkLoadHistoryCourcesService>().InstancePerDependency();

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
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
                app.UseHsts();
            }
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.ConfigureCustomExceptionMiddleware();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.ConfigureCustomExceptionMiddleware();
            UpdateDatabase(app, configManager);
        }

        private static void UpdateDatabase(IApplicationBuilder app, ConfigManager configManager)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<CourcesDbContext>())
                {
                    if (configManager.DataBase.Type == DataBaseType.SQL.ToString())
                        context.Database.Migrate();
                    Seed(context);
                }
            }
        }

        private static void Seed(CourcesDbContext context)
        {
            if (context.Cource.Count() == 0)
            {
                var courceList = new List<Cource>();
                courceList.Add(new Cource() { Name = "Blockchain and HR", Duration = 8 });
                courceList.Add(new Cource() { Name = "Compensation & Benefits", Duration =32 });
                courceList.Add(new Cource() { Name = "Digital HR", Duration = 40 });
                courceList.Add(new Cource() { Name = "Digital HR Strategy", Duration = 10 });
                courceList.Add(new Cource() { Name = "Digital HR Transformation", Duration = 8 });
                courceList.Add(new Cource() { Name = "Diversity & Inclusion", Duration = 20 });
                courceList.Add(new Cource() { Name = "Employee Experience & Design Thinking", Duration = 12 });
                courceList.Add(new Cource() { Name = "Employer Branding", Duration = 6 });
                courceList.Add(new Cource() { Name = "Global Data Integrity", Duration = 12 });
                courceList.Add(new Cource() { Name = "Hiring & Recruitment Strategy", Duration = 15 });
                courceList.Add(new Cource() { Name = "HR Analytics Leader", Duration = 21 });
                courceList.Add(new Cource() { Name = "HR Business Partner 2.0", Duration = 40 });
                courceList.Add(new Cource() { Name = "HR Data Analyst", Duration = 18 });
                courceList.Add(new Cource() { Name = "HR Data Science in R", Duration = 12 });
                courceList.Add(new Cource() { Name = "HR Data Visualization", Duration = 12 });
                courceList.Add(new Cource() { Name = "HR Metrics & Reporting", Duration = 40 });
                courceList.Add(new Cource() { Name = "Learning & Development", Duration = 30 });
                courceList.Add(new Cource() { Name = "Organizational Development", Duration = 30 });
                courceList.Add(new Cource() { Name = "People Analytics", Duration = 40 });
                courceList.Add(new Cource() { Name = "Statistics in HR", Duration = 15 });
                courceList.Add(new Cource() { Name = "Strategic HR Leadership", Duration = 34 });
                courceList.Add(new Cource() { Name = "Strategic HR Metrics", Duration = 17 });
                courceList.Add(new Cource() { Name = "Talent Acquisition", Duration = 40 });


                context.Cource.AddRange(courceList);
                context.SaveChanges();
            }
        }
    }
}
