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
    public class EmployeeRepository : IEntityRepository<Employee>
    {
        AppDbContext Context;

        public EmployeeRepository(AppDbContext context)
        {
            Context = context;
        }
        public int Add(Employee entity)
        {
            Context.Employees.Add(entity);

            return Context.SaveChanges();
        }
        public int Delete(Employee entity)
        {
            Context.Employees.Remove(entity);

            return Context.SaveChanges();

        }

        public Employee Get(int id)
        {
            return Context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return Context.Employees.AsNoTracking().ToList();
        }

        public int Update(Employee entity)
        {
            Context.Employees.Update(entity);
            return Context.SaveChanges();
        }
    }
}

