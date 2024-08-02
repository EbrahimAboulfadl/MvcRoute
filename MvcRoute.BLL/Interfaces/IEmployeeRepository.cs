using MvcRoute.DAL.Models;
using System.Linq;


namespace MvcRoute.BLL.Interfaces
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByAddress(string address);
    }
}
