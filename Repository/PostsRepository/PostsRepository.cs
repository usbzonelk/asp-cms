using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using aspCMS.Data;
using aspCMS.Models;
using System.Linq.Expressions;
using aspCMS.Repository;

namespace aspCMS.Repository.PostsRepository
{
    public class PostsRepository : Repository<Post>, IPostsRepository
    {
        private AppDBContext _db;
        public PostsRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public Post GetPostBySlug(string slug)
        {
            return dbSet.Where(post => post.Slug == slug).FirstOrDefault();
        }

        public void EditPost(Post newPost)
        {
            dbSet.Update(newPost);
        }
    }

}