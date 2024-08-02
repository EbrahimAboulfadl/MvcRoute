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
    public class DepartmentRepository : EntityRepository<Department>,IDepartmentRepository
    {
       

        public DepartmentRepository(AppDbContext context):base(context) 
        {
          
        }


    }
}
