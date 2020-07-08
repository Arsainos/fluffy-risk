using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Certificates
{
    public class Keys
    {
        public static readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("3DF8A754E8BEBE4A83FEDA6FFC7A8"));
    }
}
