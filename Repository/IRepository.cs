using System;
using System.Collections.Generic;

namespace aspCMS.Repository;
public interface IRepository<TEntity>
{
    TEntity GetById(int id);
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}