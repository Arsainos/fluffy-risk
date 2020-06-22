using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Aggregator.Models
{
    public class ClientInfo
    {
        public int clientId { get; set; }
        public int clientInn { get; set; }
        public string clientName { get; set; }
        public string clientsHolding { get; set; }
    }
}
