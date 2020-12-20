using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public class AppUser : IdentityUser<long>, IUser
    {
        public string Name { get; set; }
    }
}
