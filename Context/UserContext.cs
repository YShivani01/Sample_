using AuthorizationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Context
{
    [ExcludeFromCodeCoverage]
    public class UserContext: DbContext
    {
        public UserContext() { }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public virtual DbSet<UserCredentials> Users { get; set; }

        
    }
}
