using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using RouteMvcProject.DAL.Data;
using System.IO;
using System.Linq;


namespace MvcRoute.BLL.Repositories
{
    public class EmployeeRepository : EntityRepository<Employee>,IEmployeeRepository
    {
        readonly AppDbContext Context;

        public EmployeeRepository(AppDbContext context):base(context)
        {
            Context = context;
        }
        public override int Delete(Employee entity ,string directoryPath =null)
        {
            var empToDelete = Get(entity.Id);
            string imagePath = "";
            if (empToDelete.Image != null)
            {
                 imagePath = empToDelete.Image;

            }
            int deleted = base.Delete(empToDelete);
            if (deleted > 0 && imagePath != string.Empty) 
            {
                try {
                    string folderPath = Path.Combine(directoryPath, "wwwroot\\assets", "images", imagePath);
                    File.Delete(folderPath);
                }
                catch { }
          
                
            }
            return deleted;

        }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return Context.Employees.Where(e => e.Address.Contains(address));
        }


    }
}

