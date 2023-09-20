using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using aspCMS.Data;
using Microsoft.EntityFrameworkCore;

namespace aspCMS.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _db;
        internal DbSet<TEntity> dbSet;

        public Repository(AppDBContext db)
        {
            _db = db;
            dbSet = _db.Set<TEntity>();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> find)
        {
            IQueryable<TEntity> query = dbSet;
            TEntity? found = query.Where(find).FirstOrDefault();
            return found;
        }

        public List<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            List<TEntity> found = query.ToList();
            return found;
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}