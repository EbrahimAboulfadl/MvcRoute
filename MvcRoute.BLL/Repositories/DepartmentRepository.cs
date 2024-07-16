using Microsoft.EntityFrameworkCore;
using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using RouteMvcProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRoute.BLL.Repositories
{
    public class DepartmentRepository : IEntityRepository<Department>
    {
        AppDbContext Context;

        public DepartmentRepository(AppDbContext context)
        {
            Context = context;
        }

        public int Add(Department entity)
        {
           Context.Departments.Add(entity);
           
           return Context.SaveChanges();
                
        }

        public int Delete(Department entity)
        {
            Context.Departments.Remove(entity);

            return Context.SaveChanges();

        }

        public Department Get(int id)
        {
          return Context.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
           return Context.Departments.AsNoTracking().ToList();
        }

        public int Update(Department entity)
        {
              Context.Departments.Update(entity);
              return Context.SaveChanges();
        }
    }
}
