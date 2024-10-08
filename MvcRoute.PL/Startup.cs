using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcRoute.BLL.Interfaces;
using MvcRoute.BLL.Repositories;
using MvcRoute.DAL.Models;
using MvcRoute.PL.Mapping_Profiles;
using RouteMvcProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRoute.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        List < Profile> profiles = new List<Profile>() { 
        new UserProfile(),
        new EmployeeProfile(),
        };
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddTransient<AppDbContext>();
            //services.AddSingleton<AppDbContext>();
            //services.AddScoped<AppDbContext>();

            //services.AddScoped<DbContextOptions<AppDbContext>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(p=>p.AddProfiles(profiles));
            services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContext<AppDbContext>(
            options =>
            //options.UseSqlServer(Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value)
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            
            
         );

            services.AddTransient<IEntityRepository<Department>, DepartmentRepository>();
            services.AddTransient<IEntityRepository<Employee>, EmployeeRepository>(); 
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
