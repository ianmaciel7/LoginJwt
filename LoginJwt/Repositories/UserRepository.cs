
using LoginJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginJwt.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> _users = new List<User>()
        {
            new User(){UserId = 1,UserName="teste",Password="123",Role="Admin"},
            new User(){UserId = 2,UserName="teste2",Password="123",Role="Admin"}

        };

        public User GetUser(string username,string password)
        {
            return _users.Where(u => u.UserName.ToLower() == username.ToLower() && u.Password.ToLower() == password).FirstOrDefault();
        }
    }
}