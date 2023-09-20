using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using aspCMS.Data;
using aspCMS.Models;
using System.Linq.Expressions;

namespace aspCMS.Repository.UsersRepository
{
    public class PostsRepository : Repository<User>, IUsersRepository
    {
        private AppDBContext _db;
        public PostsRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public User GetUserByEmail(string email)
        {
            return dbSet.Where(user => user.Email == email).FirstOrDefault();
        }

        public void EditUser(User newUserInfo)
        {
            dbSet.Update(newUserInfo);
            _db.SaveChanges();
        }
    }
}