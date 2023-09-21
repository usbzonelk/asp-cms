using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using aspCMS.Repository.PostsRepository;
using aspCMS.Data;
using aspCMS.Models;
using aspCMS.Repository.CategoryRepository;

namespace aspCMS.Repository;
public class UnitOfWork : IUnitOfWork
{
    private AppDBContext _db;
    public IPostsRepository Posts { get; private set; }
    public ICategoryRepository Categories { get; private set; }

    public UnitOfWork(AppDBContext db)
    {
        _db = db;
        Posts = new PostsRepository.PostsRepository(_db);
        Categories = new CategoryRepository.CategoryRepository(_db);
    }



    public void Save()
    {
        _db.SaveChanges();
    }
}