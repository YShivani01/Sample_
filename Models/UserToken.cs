using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Models
{
    public class UserToken
    {
        
      //  public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public string Address { get; set; }
      
    }
}
