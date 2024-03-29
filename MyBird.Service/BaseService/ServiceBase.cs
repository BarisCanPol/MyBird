﻿using MyBird.Core.Entity;
using MyBird.Core.Service;
using MyBird.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Service.BaseService
{
    public class ServiceBase<T> : ICoreService<T> where T : CoreEntity
    {
        private static ProjectContext _context;

        public ProjectContext context
        {
            get
            {
                if (_context==null)
                {
                    _context = new ProjectContext();
                    return _context;

                }
                return _context;
            }
            set { _context = value; }
        }
        public void Add(T item)
        {
            context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            context.Set<T>().AddRange(items);
            Save();
        }
      
        public List<T> GetActive()
        {
            return context.Set<T>().Where(x => x.Status == Core.Enum.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public bool Any(Expression<Func<T, bool>> exp) => context.Set<T>().Any(exp);

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = Core.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(Guid id)
        {
            T item = GetByID(id);
            item.Status = Core.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Core.Enum.Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetByID(item.ID);
            DbEntityEntry entry = context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
        public T GetLastOrDefault(Expression<Func<T, bool>> exp)
        {

            return context.Set<T>().Where(exp).ToList().LastOrDefault();
        }
    }
}
