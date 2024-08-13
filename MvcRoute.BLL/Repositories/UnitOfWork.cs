using MvcRoute.BLL.Interfaces;
using RouteMvcProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRoute.BLL.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext dbContext) {
        EmployeeRepository =  new EmployeeRepository(dbContext);

        DepartmentRepository = new DepartmentRepository(dbContext);

        UsersRepository = new UsersRepository(dbContext);

        }
        public IEmployeeRepository EmployeeRepository { get ; set; }
        public IDepartmentRepository DepartmentRepository { get ; set; }
        public IUsersRepository UsersRepository { get ; set; }

    }
}
