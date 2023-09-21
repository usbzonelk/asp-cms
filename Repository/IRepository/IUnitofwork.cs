using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using aspCMS.Repository.CategoryRepository;
using aspCMS.Repository.PostsRepository;

namespace aspCMS.Repository;
public interface IUnitOfWork
{
    IPostsRepository Posts { get; }
    ICategoryRepository Categories { get; }
    void Save();
}