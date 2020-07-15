using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Aggregator.Config
{
    public class UrlsConfig
    {
        public string Clients { get; set; }
        public string Accounts { get; set; }
        public string ClientsGrpc { get; set; }
        public string AccountsGrpc { get; set; }
    }
}
