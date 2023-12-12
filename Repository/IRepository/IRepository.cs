using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace aspCMS.Repository;
public interface IRepository<TEntity> where TEntity : class
{
    TEntity Get(Expression<Func<TEntity, bool>> find);
    // Passes a LINQ operation as a parameter named find
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> find);
    List<TEntity> GetAll();
    void Add(TEntity entity);
    void Remove(TEntity entity);
}