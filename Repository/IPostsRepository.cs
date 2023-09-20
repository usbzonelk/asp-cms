using System;
using System.Collections.Generic;

using aspCMS.Models;

namespace aspCMS.Repository;

public interface IPostsRepository : IRepository<Post>
{
   public Post GetPostBySlug(string slug);
}