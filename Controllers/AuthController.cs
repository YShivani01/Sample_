using AuthorizationAPI.Models;
using AuthorizationAPI.Repository;
using AuthorizationAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly log4net.ILog _log4Net;
        public AuthController(IUserService _userService)
        {
            userService = _userService;
            _log4Net = log4net.LogManager.GetLogger(typeof(AuthController));

        }


        [HttpPost]
        public string ValidateUser([FromBody] UserToken user)
        {
            var validuser = userService.GetUser(user);
            if (validuser == null)
            {
                _log4Net.Info("No Such User");
                return "User Not Found";
            }
            else
            {
                string tokenString = userService.GenerateJSONWebToken("UserToken");
                _log4Net.Info("User is Found");
                _log4Net.Info("Token is Generated");
                return tokenString;
            }

        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            _log4Net.Info("Getting All Users");
            return Ok(userService.GetAllUsers().ToList());
        }

    }

}
