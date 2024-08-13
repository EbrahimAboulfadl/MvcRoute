using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRoute.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        IDepartmentRepository DepartmentRepository { get; set; }
        IUsersRepository UsersRepository { get; set; }
    }
}
