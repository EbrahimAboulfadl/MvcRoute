using Microsoft.EntityFrameworkCore;
using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using RouteMvcProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcRoute.BLL.Repositories
{
    public class EmployeeRepository : EntityRepository<Employee>,IEmployeeRepository
    {
        AppDbContext Context;

        public EmployeeRepository(AppDbContext context):base(context)
        {
            Context = context;
        }

        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return Context.Employees.Where(e => e.Address.Contains(address));
        }


    }
}

