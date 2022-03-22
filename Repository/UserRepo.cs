using AuthorizationAPI.Context;
using AuthorizationAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    //[ExcludeFromCodeCoverage]
    public class UserRepo:IUserRepo
    {
        private readonly UserContext _usercontext;
        public UserRepo(UserContext userContext)
        {
            _usercontext = userContext;
        }

        public List<UserCredentials> GetAllUsers()
        {
            List<UserCredentials> users = _usercontext.Users.ToList();
            return users;
        }

        public UserCredentials GetUser(UserToken user)
        {
            return GetAllUsers().SingleOrDefault(a => a.Username == user.Username && a.Password == user.Password);
        }


        
    }
}
