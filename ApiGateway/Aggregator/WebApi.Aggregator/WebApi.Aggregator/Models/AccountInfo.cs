using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Aggregator.Models
{
    public class AccountInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
