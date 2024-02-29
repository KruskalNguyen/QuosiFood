﻿using Data.Abtract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShopiiContext _context;

        public Repository(ShopiiContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetData(Expression<Func<T,bool>> expression = null)
        {
            if(expression == null)
            {
                return await _context.Set<T>().ToListAsync();
            }

            return await _context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<T> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }
        public async Task Insert(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Delete(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            if (entities.Count() > 0)
            {
                _context.Set<T>().RemoveRange(entities);
            }
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entities = _context.Set<T>().Where(expression).ToList();

            if(entities.Count > 0)
            {
                _context.Set<T>().RemoveRange(entities);
            }
        }

        public virtual IQueryable<T> Table => _context.Set<T>();

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
