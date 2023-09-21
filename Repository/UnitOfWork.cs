using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using aspCMS.Repository.PostsRepository;
using aspCMS.Data;
using aspCMS.Models;

namespace aspCMS.Repository;
public class UnitOfWork : IUnitOfWork
{
    private AppDBContext _db;
    public IPostsRepository Posts { get; private set; }

    public UnitOfWork(AppDBContext db)
    {
        _db = db;
        Posts = new PostsRepository.PostsRepository(_db);
    }



    public void Save()
    {

    }
}