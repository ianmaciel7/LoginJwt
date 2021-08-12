using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginJwt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginJwt.Exceptions;
using LoginJwt.Models;
using LoginJwt.InputModel;
using Microsoft.AspNetCore.Authorization;

namespace LoginJwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        

        public TokenController(IUserService userService,ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]UserInputModel model)
        {
            try
            {
                var user = _userService.GetUser(model.UserName, model.Password);
                var token = _tokenService.GenerateToken(user);
                return Ok(new { 
                user,
                token
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Required")]      
        public async Task<ActionResult> Get()
        {
            return Ok("test"+ User.Identity.Name);
        }
    }
}
