using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DbEftest.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneNumber1 { get; set; }
        public string Country { get; set; }

    }

    public class ClientOrders
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Country { get; set; }
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }

}
