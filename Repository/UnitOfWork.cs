using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using aspCMS.Repository.PostsRepository;

namespace aspCMS.Repository;
public class UnitOfWork : IUnitOfWork
{
    public IPostsRepository PostsRepository => throw new NotImplementedException();



    public void Save()
    {

    }
}