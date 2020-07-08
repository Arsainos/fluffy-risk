using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Certificates
{
    public class Keys
    {
        public static readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());
    }
}
