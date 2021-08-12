using LoginJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginJwt.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}