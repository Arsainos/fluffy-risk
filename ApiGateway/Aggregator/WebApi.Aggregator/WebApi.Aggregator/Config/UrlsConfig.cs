using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Aggregator.Config
{
    public class UrlsConfig
    {
        public static string GrpcClients => "https://localhost:5001";
        public static string GrpcAccounts => "https://localhost:5002";
    }
}
