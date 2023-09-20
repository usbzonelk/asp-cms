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
        TEntity IRepository<TEntity>.Get(Expression<Func<TEntity, bool>> findPost)
        {
            throw new NotImplementedException();

        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}