using LoginJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginJwt.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}