using Microsoft.EntityFrameworkCore;
using MvcRoute.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RouteMvcProject.DAL.Data
{

    public class AppDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>

        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RouteMvcProject;Integrated Security=True;Trust Server Certificate=True");
        
    }
}
