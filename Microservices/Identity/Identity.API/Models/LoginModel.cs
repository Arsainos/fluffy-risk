using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Models
{
    public class LoginModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
