using System;
using System.Collections.Generic;

using aspCMS.Models;

namespace aspCMS.Repository.UsersRepository

{
    public interface IUsersRepository : IRepository<User>
    {
        public User GetUserByEmail(string email);

        public void EditUser(User newUserInfo);
    }
}