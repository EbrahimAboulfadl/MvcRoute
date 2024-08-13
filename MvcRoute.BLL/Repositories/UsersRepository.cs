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
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext dbContext;

        public UsersRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return dbContext.Users;
        }
    }
}
