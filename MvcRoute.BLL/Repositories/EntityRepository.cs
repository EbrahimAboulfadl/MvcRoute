using MvcRoute.BLL.Interfaces;
using RouteMvcProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcRoute.BLL.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public EntityRepository(AppDbContext _context)
        {
            context = _context;
        }
        public int Add(T entity)
        {
           context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public virtual int Delete(T entity,string directory =null)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public T Get(int id) => context.Set<T>().Find(id);


        public IEnumerable<T> GetAll() => context.Set<T>().ToList();

        public int Update(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();
        }
    }
}
