﻿using MvcRoute.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRoute.BLL.Interfaces
{
    public interface IEntityRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        int Add(T entity);

        int Update(T entity);

        int Delete(T entity);

    }
}
