using AuthorizationAPI.Models;
using AuthorizationAPI.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationAPI.Service
{
    [ExcludeFromCodeCoverage]
    public class UserService:IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IConfiguration _config;

        public UserService(IUserRepo _userRepo, IConfiguration config)
        {
            userRepo = _userRepo;
            _config = config;
        }

        /// <summary>
        /// Retriving List of Agents
        /// </summary>
        /// <returns>List of Agents</returns>
        public List<UserCredentials> GetAllUsers()
        {
            return userRepo.GetAllUsers();
        }

        /// <summary>
        /// Method for retriving Agent
        /// </summary>
        /// <param name="user"></param>
        /// <returns>If user is not null then it returns Agent otherwise null</returns>
        public UserCredentials GetUser(UserToken user)
        {
            if (user == null)
            {
                return null;
            }
            else
            {
                return userRepo.GetUser(user);
            }

        }

        /// <summary>
        /// Generating token for authorization
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns>Token</returns>
        public string GenerateJSONWebToken(string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Role, userRole),
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
 

