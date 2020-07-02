using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Login { get; set; }
        public string LDAPLogin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
