using AuthorizationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    public interface IUserRepo
    {
        public List<UserCredentials> GetAllUsers();
        public UserCredentials GetUser(UserToken user);
    }
}
