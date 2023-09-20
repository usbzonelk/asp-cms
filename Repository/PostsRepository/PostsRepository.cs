using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using aspCMS.Data;
using aspCMS.Models;
using System.Linq.Expressions;

namespace aspCMS.Repository.PostsRepository
{
    public class PostsRepository : IPostsRepository
    {
        private readonly AppDBContext _db;
        public Post GetPostBySlug(string slug)
        {
            return null;
        }

        public void Remove(Post post)
        {

        }
        public PostsRepository(AppDBContext context)
        {
            _db = context;
        }

        public Post Get(Expression<Func<Post, bool>> findPost)
        {
            return null;
        }

        public IEnumerable<Post> GetAll()
        {
            return _db.Posts.ToList();
        }

        public void Add(Post newPost)
        {
            _db.Posts.Add(newPost);
            _db.SaveChanges();
        }

        public void Update(Post updatedPost)
        {
            _db.Entry(updatedPost).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int postID)
        {
            var postToDelete = _db.Posts.Find(postID);
            if (postToDelete != null)
            {
                _db.Posts.Remove(postToDelete);
                _db.SaveChanges();
            }
        }

    }
}