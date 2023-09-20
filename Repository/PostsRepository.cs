using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using aspCMS.Data;
using aspCMS.Models;

namespace aspCMS.Repository;
public class PostsRepository : IPostsRepository
{
    private readonly AppDBContext _context;
    public Post GetPostBySlug(string slug)
    {
        return null;
    }

    public void Remove(Post post)
    {

    }
    public PostsRepository(AppDBContext context)
    {
        _context = context;
    }

    public Post GetById(int postId)
    {
        return _context.Posts.Find(postId);
    }

    public IEnumerable<Post> GetAll()
    {
        return _context.Posts.ToList();
    }

    public void Add(Post newPost)
    {
        _context.Posts.Add(newPost);
        _context.SaveChanges();
    }

    public void Update(Post updatedPost)
    {
        _context.Entry(updatedPost).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int postID)
    {
        var postToDelete = _context.Posts.Find(postID);
        if (postToDelete != null)
        {
            _context.Posts.Remove(postToDelete);
            _context.SaveChanges();
        }
    }
}