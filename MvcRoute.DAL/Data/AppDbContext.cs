using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcRoute.DAL.Models;
using System.Reflection;

namespace RouteMvcProject.DAL.Data
{

    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> _options) : base(_options) { } 
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RouteMvcProject;Integrated Security=True;Trust Server Certificate=True");

        //    }


        //}


    }
}
