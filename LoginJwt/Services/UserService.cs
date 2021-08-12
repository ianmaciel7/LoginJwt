using LoginJwt.Exceptions;
using LoginJwt.Models;
using LoginJwt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace LoginJwt.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository; 
        private readonly ITokenService _tokenService;
        
        public UserService(IUserRepository userRepository,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public User GetUser(string username, string password)
        {
            var user = _userRepository.GetUser(username, password);
            if (user == null) throw new UserNotFoundException();          
            return user; 
        }
    }
}