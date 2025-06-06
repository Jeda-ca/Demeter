﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }

}
