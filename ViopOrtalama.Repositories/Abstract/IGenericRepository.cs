﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViopOrtalama.Entities.Enitities;

namespace ViopOrtalama.Repositories.Abstract
{
   public interface IGenericRepository<T>  where T : class, IBaseEntity
    {
        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        List<T> GetAll(string[] includes);
        List<T> GetActive(string[] includes);
        bool Add(T item);
        bool SetPassive(int id);
        bool SetPassive(Expression<Func<T, bool>> exp);
        bool Remove(T item);
        bool Activate(Guid id);
        bool Activate(int id);
        bool Update(T item);
        bool Update(List<T> items);
        bool Save();




    }
}
