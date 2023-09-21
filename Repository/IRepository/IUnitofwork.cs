using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using aspCMS.Repository.PostsRepository;

namespace aspCMS.Repository;
public interface IUnitOfWork
{
    IPostsRepository Posts { get; }

    void Save();
}