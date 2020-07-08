using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Clients.API.Certificates
{
    public class Keys
    {
        public static readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("3DF8A754E8BEBE4A83FEDA6FFC7A8"));
    }
}
